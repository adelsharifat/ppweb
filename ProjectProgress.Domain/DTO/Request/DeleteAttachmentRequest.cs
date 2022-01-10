using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class DeleteAttachmentRequest
    {
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
