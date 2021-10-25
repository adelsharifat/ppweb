using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using ProjectProgress.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Service
{
    public class TokenService:ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IOptionsMonitor<JwtOptions> jwtOptions,IUnitOfWork unitOfWork)
        {
            _jwtOptions = jwtOptions.CurrentValue;
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationResult> AddTokenAsync(RefreshToken token)
        {
            try
            {
                await _unitOfWork.TokenRepo.CREATE_ASYNC(token);
                var result = await _unitOfWork.Commit();
                _unitOfWork.Dispose();

                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Add token to server faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false,ex.Message);
            }
        }

        public string GenerateAccessToken(AppUser user)
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

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshToken> GetTokenAsync(Expression<Func<RefreshToken, bool>> expressions)
        {
            try
            {
                return await _unitOfWork.TokenRepo.GET_ASYNC(expressions);                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MutationResult> UpdateTokenAsync(RefreshToken token)
        {
            try
            {
                await _unitOfWork.TokenRepo.UPDATE_ASYNC(token);
                var result = await _unitOfWork.Commit();
                _unitOfWork.Dispose();

                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Update token to server faild");                 
            }
            catch (Exception ex)
            {
                return new MutationResult(false, ex.Message);
            }
        }
    }
}
