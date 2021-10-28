using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class AttachmentRequest
    {
        public string FileName { get; set; }
        public string Remark { get; set; }
        public byte[] FileStream { get; set; }
        public int ItemId { get; set; }
        public int CreatedBy { get; set; }
    }
}
