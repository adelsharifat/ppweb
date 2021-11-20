using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectProgress.Domain.DTO.Response;
using ProjectProgress.Service.Interface;

namespace ProjectProgress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var data = await _itemService.GetAllAsync();
                if(data == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK, Error = new List<string> { "empty data" } });
                return Ok(new ApiResponse { Payload = data, StatusCode = StatusCodes.Status200OK });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK,Error = new List<string> { ex.Message } });                
            }
        }

        [HttpGet]
        [Route("GetItemById/{itemId}")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            try
            {
                var item = await _itemService.GetAsync(x => x.Id == itemId);
                if (item == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status400BadRequest, Error = new List<string> { "item not found" } });

                return Ok(new ApiResponse { Payload = item, StatusCode = StatusCodes.Status200OK });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string>() { ex.Message } });
            }
        }
    }
}





           