using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectProgress.Domain.DTO.Response;

namespace ProjectProgress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            try
            {
                return await Task.Run(() => Ok(new ApiResponse { Payload = "Hello World", Error = null, StatusCode = StatusCodes.Status200OK }));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}