using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class AttachmentRequest
    {
        public int CreatedBy { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        public int ItemId { get; set; }
        public string Remark { get; set; }
        public DateTime AttachmentDate { get; set; }
    }
}
