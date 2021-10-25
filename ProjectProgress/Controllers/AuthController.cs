using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Request;
using ProjectProgress.Domain.DTO.Response;
using ProjectProgress.Domain.DTO.Shared;
using ProjectProgress.Service.Interface;
using static ProjectProgress.Utils.AppHelpers;

namespace ProjectProgress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ITokenService _tokenService;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly JwtOptions _jwtOptions;

        public AuthController(IUserManager userManager,ITokenService tokenService,TokenValidationParameters tokenValidationParameters,IOptionsMonitor<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _tokenValidationParameters = tokenValidationParameters;
            _jwtOptions = jwtOptions.CurrentValue;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok("Worked!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            try
            {
                var user =await _userManager.FindUserAsync(x => x.UserName == loginRequest.UserName);
                if (user == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status401Unauthorized,Error = new List<string> {"User not found"} });

                if(user.Password != BCrypt.HashPassword(loginRequest.Password,user.Salt,1010,70)) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string> { "Password incorect!" } });

                var authResult = await GenerateJwtTokenAsync(user);

                if(authResult.Success)
                    return Ok(new ApiResponse { Payload = new { Token = authResult.Token, RefreshToken = authResult.RefreshToken }, StatusCode = StatusCodes.Status200OK });

                return BadRequest(new ApiResponse {StatusCode = StatusCodes.Status401Unauthorized,Error=new List<string> { "token payload is null" } });
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string>() { ex.Message } });
            }
        }

        [HttpPost, Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var res = await VerifyToken(tokenRequest);

                if (res == null)
                {
                    return BadRequest(new ApiResponse()
                    {
                        Error = new List<string>() { "Invalid tokens" },
                        StatusCode = StatusCodes.Status401Unauthorized
                    });
                }

                return Ok(res);
            }

            return BadRequest(new ApiResponse()
            {
                Error = new List<string>() {
                "Invalid payload"
            },
                StatusCode = StatusCodes.Status401Unauthorized
            });
        }



        // JWT Helpers
        private async Task<AuthResult> GenerateJwtTokenAsync(AppUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.Expire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            foreach (UserRole userRole in user.UserRoles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role,userRole.Role.Name.ToLower()));
            }

            var accessToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(accessToken);

            var refreshToken = new RefreshToken()
            {
                JwtId = accessToken.Id,
                IsUsed = false,
                CreatedBy = user.Id,
                ExpiryDate = DateTime.UtcNow.AddHours(_jwtOptions.RefreshTokenExpire),
                Token = RandomString(25) + Guid.NewGuid()
            };

            await _tokenService.AddTokenAsync(refreshToken);

            return new AuthResult()
            {
                Token = jwtToken,
                Success = true,
                RefreshToken = refreshToken.Token
            };
        }
        public string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private async Task<AuthResult> VerifyToken(TokenRequest tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (result == false)
                    {
                        return null;
                    }
                }

                var utcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expDate = UnixTimeStampToDateTime(utcExpiryDate);

                if (expDate > DateTime.UtcNow)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "We cannot refresh this since the token has not expired" },
                        Success = false
                    };
                }

                var storedRefreshToken = await _tokenService.GetTokenAsync(x => x.Token == tokenRequest.RefreshToken);

                if (storedRefreshToken == null)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "refresh token doesnt exist" },
                        Success = false
                    };
                }

                if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has expired, user needs to relogin" },
                        Success = false
                    };
                }

                if (storedRefreshToken.IsUsed)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has been used" },
                        Success = false
                    };
                }

                if (storedRefreshToken.IsActive)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has been revoked" },
                        Success = false
                    };
                }

                // we are getting here the jwt token id
                var jti = principal.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                // check the id that the recieved token has against the id saved in the db
                if (storedRefreshToken.JwtId != jti)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "the token doenst mateched the saved token" },
                        Success = false
                    };
                }

                storedRefreshToken.IsUsed = true;
                var updateResult = await _tokenService.UpdateTokenAsync(storedRefreshToken);

                if(!updateResult.Successed)
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "update refresh token faild in the server!" },
                        Success = false
                    };

                var dbUser = await _userManager.FindUserAsync(x=>x.CreatedBy == storedRefreshToken.CreatedBy);
                return await GenerateJwtTokenAsync(dbUser);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AuthRequest authRequest)
        {
            try
            {
                var checkExistUser = await _userManager.FindUserAsync(x => x.UserName == authRequest.UserName);
                if (checkExistUser != null) throw new Exception("UserName alredy exist in the server!");

                var salt = BCrypt.GenerateSalt(70);

                AppUser newUser = new AppUser();
                newUser.UserName = authRequest.UserName;
                newUser.Salt = salt;
                newUser.Password = BCrypt.HashPassword(authRequest.Password,salt,1010,70);

                var result = await _userManager.CreateUserAsync(newUser);
                if(result.Successed)
                {
                    // login here

                    return Ok(new ApiResponse() {StatusCode = StatusCodes.Status200OK});
                }

                return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status400BadRequest });
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

    



    }
}