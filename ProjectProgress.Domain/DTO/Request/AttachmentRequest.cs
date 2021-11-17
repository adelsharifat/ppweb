using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class AttachmentDto
    {
        public int CreatedBy { get; set; }
        public string FileName { get; set; }
        public byte[] FileStream { get; set; }
        public int ItemId { get; set; }
        public string Remark { get; set; }
    }

    public class AttachmentRequest
    {
        public AttachmentDto[] attachments { get; set; }
    }
}
