using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class AttachmentDto
    {
        public string FileName { get; set; }
        public byte[] FileStream { get; set; }
    }

    public class AttachmentRequest
    {
        public AttachmentDto[] Files { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public int ItemId { get; set; }
    }
}
