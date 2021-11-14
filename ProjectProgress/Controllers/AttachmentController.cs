using System;
using System.Collections.Generic;
using System.IO;
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
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }


        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(new ApiResponse(StatusCodes.Status200OK, await _attachmentService.GETALL_ASYNC()));
            }
            catch (Exception ex)
            {            
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError,ex.Message));
            }
        }


        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                return Ok(new ApiResponse(StatusCodes.Status200OK, await _attachmentService.GET_ASYNC(x=>x.Id == Id)));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }


        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                return Ok(new ApiResponse(StatusCodes.Status200OK, await _attachmentService.GET_ASYNC(x => x.FileName == name)));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        public async Task<IActionResult> AddAttachment([FromBody] AttachmentRequest attachmentRequest)
        {
            try
            {

                Attachment model = new Attachment();
                model.FileName = attachmentRequest.FileName;
                
                var insertedAttachment = await _attachmentService.SaveAttachment(model,attachmentRequest.FileStream);
                model.StreamId =(Guid)insertedAttachment["stream_id"];
                model.FileName = insertedAttachment["name"].ToString();
                model.ObjectId = attachmentRequest.ItemId;
                model.FileType = insertedAttachment["file_type"].ToString();
                model.Remark = attachmentRequest.Remark;
                model.CreatedBy = attachmentRequest.CreatedBy;
                model.CreatedDate = DateTime.Now;
                await _attachmentService.ADD_ASYNC(model);
                return Ok(new ApiResponse(StatusCodes.Status201Created, model));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }


        public async Task<IActionResult> UpdateAttachment([FromBody] AttachmentRequest attachmentRequest)
        {
            try
            {
                var fileExtention = Path.GetExtension(attachmentRequest.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtention;
                var streamId = Guid.NewGuid();
                var model = new Attachment()
                {
                    FileName = fileName,
                    ObjectId = attachmentRequest.ItemId,
                    IsDelete = false,
                    FileType = fileExtention,
                    StreamId = streamId,
                    Remark = attachmentRequest.Remark
                };
                await _attachmentService.ADD_ASYNC(model);
                return Ok(new ApiResponse(StatusCodes.Status201Created, model));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }









    }
}