using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Request;
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
        [Route("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var data = await _itemService.GetAllAsync();
                if (data == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK, Error = new List<string> { "empty data" } });
                return Ok(new ApiResponse { Payload = data.Where(x=>x.ParentId == null), StatusCode = StatusCodes.Status200OK });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK, Error = new List<string> { ex.Message } });
            }
        }

        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var data = await _itemService.GetAllAsync(x => x.ParentId == null && x.ItemsType == 0);
                if(data == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK, Error = new List<string> { "empty data" } });
                return Ok(new ApiResponse { Payload = data, StatusCode = StatusCodes.Status200OK });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK,Error = new List<string> { ex.Message } });                
            }
        }

        [HttpGet]
        [Route("GetManagementItems")]
        public async Task<IActionResult> GetManagementItems()
        {
            try
            {
                var data = await _itemService.GetAllAsync(x => x.ParentId == null && x.ItemsType == 1);
                if (data == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK, Error = new List<string> { "empty data" } });
                return Ok(new ApiResponse { Payload = data, StatusCode = StatusCodes.Status200OK });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status200OK, Error = new List<string> { ex.Message } });
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


        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] ItemAddRequest itemAddRequest)
        {
            try
            {
                Item item = new Item
                {
                    Name = itemAddRequest.Name,
                    ItemsType = itemAddRequest.ItemType,
                    ParentId = itemAddRequest.ParentId,
                    CreatedBy = itemAddRequest.UserId,
                    CreatedDate =DateTime.Now,                                       
                };

                var result = await _itemService.AddAsync(item);

                if(result.Successed)
                    return Ok(new ApiResponse { Payload = item, StatusCode = StatusCodes.Status200OK });
                else
                    return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string>() { "Add Item operation Faild!" } });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string>() { ex.Message } });
            }
        }


        [HttpGet]
        [Route("DeleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(int itemId)
        {
            try
            {
                var item = await _itemService.GetAsync(x => x.Id == itemId);
                if (item == null) return BadRequest(new ApiResponse { StatusCode = StatusCodes.Status400BadRequest, Error = new List<string> { "item not found" } });

                item.IsDelete = true;
                var result = await _itemService.DeleteAsync(item);

                if (result.Successed)
                    return Ok(new ApiResponse { Payload = "Operation Success!", StatusCode = StatusCodes.Status200OK });
                else
                    return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string>() { "Add Item operation Faild!" } });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse() { StatusCode = StatusCodes.Status401Unauthorized, Error = new List<string>() { ex.Message } });
            }
        }
    }
}





           