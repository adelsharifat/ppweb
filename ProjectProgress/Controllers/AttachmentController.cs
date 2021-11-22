using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Request;
using ProjectProgress.Domain.DTO.Response;
using ProjectProgress.Service.Interface;

namespace ProjectProgress.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpGet]
        [Route("FindAll/{objectId}")]
        public async Task<IActionResult> FinByAsync(int objectId)
        {
            try
            {
                return Ok(new ApiResponse(StatusCodes.Status200OK, (await _attachmentService.Find_ASYNC(x=>x.Item.Id == objectId)).OrderByDescending(x=>x.Id)));
            }
            catch (Exception ex)
            {            
                return BadRequest(new ApiResponse(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            try
            {
                return Ok(new ApiResponse(StatusCodes.Status200OK, await _attachmentService.GET_ASYNC(x=>x.Id == Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [Route("GetByName")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            try
            {
                return Ok(new ApiResponse(StatusCodes.Status200OK, await _attachmentService.GET_ASYNC(x => x.FileName == name)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }


        [HttpGet]
        [Route("DownloadAttachment/{id}")]
        public async Task<IActionResult> DownloadAttachment(string id)
        {
            if (id == null) return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest, "null request input"));
            var data = await _attachmentService.DownloadAttachment(id);
            if (data == null)
                return NotFound();
            return Ok(new ApiResponse(StatusCodes.Status200OK, data));

        }

        [HttpPost,DisableRequestSizeLimit]
        [Route("SaveAttachments")]
        public async Task<IActionResult> SaveAttachmentsAsync([FromForm] AttachmentRequest attachmentrequest)
        {
            try
            {
                byte[] fileBytes = null;
                var file= attachmentrequest.File;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                }

                Attachment model = new Attachment();
                model.ObjectId = attachmentrequest.ItemId;
                model.FileName = Guid.NewGuid().ToString("N")+attachmentrequest.FileName;
                model.File = fileBytes;
                model.Remark = attachmentrequest.Remark;
                model.CreatedBy = attachmentrequest.CreatedBy;

                await _attachmentService.SaveAttachment(model);
                return Ok(new ApiResponse(StatusCodes.Status201Created, "Endpoint Worked"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }


        

    }
}