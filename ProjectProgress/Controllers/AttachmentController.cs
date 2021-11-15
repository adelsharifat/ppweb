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

        [HttpPost]
        [Route("GetAll")]
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

        [HttpPost]
        [Route("GetById")]
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

        [HttpPost]
        [Route("GetByName")]
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

        [HttpPost]
        [Route("SaveAttachments")]
        public async Task<IActionResult> SaveAttachments([FromBody] AttachmentRequest attachmentRequest)
        {
            try
            {
                List<Attachment> modelList = new List<Attachment>();

                foreach (var file in attachmentRequest.Files)
                {
                    Attachment model = new Attachment();
                    model.FileName = file.FileName;
                    model.File = file.FileStream;
                    model.Remark = attachmentRequest.Remark;
                    model.CreatedBy = attachmentRequest.CreatedBy;
                    modelList.Add(model);
                }

                await _attachmentService.SaveAttachments(modelList);

                return Ok(new ApiResponse(StatusCodes.Status201Created, modelList));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}