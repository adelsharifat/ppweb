using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Request;
using ProjectProgress.Domain.DTO.Response;
using ProjectProgress.Service.Interface;
using static ProjectProgress.Utils.AppHelpers;

namespace ProjectProgress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        [Route("SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody] SaveUserRequest saveUserRequest)
        {
            try
            {
                var salt = BCrypt.GenerateSalt(70);
                AppUser user = new AppUser
                {
                    UserName = saveUserRequest.UserName,
                    Password = saveUserRequest.Password,
                    FirstName = saveUserRequest.FirstName,
                    LastName = saveUserRequest.LastName,
                    Salt = salt
                };

                var result =await _userManager.CreateUserAsync(user);
                if(result.Successed)
                {
                    var dbUser =await _userManager.FindUserAsync(x => x.UserName == user.UserName);
                    if(dbUser!= null)
                    {
                        await _userManager.AddRoleAsync(dbUser,saveUserRequest.RoleId);
                        return Ok(new ApiResponse(StatusCodes.Status200OK,"Operation Success"));
                    }
                }
                return BadRequest("Operation faild");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}