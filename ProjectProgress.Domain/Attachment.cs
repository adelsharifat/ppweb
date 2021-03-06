using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace ProjectProgress.Domain
{
    public class Attachment:BaseEntity
    {
        public string FileName { get; set; }
        public string Remark { get; set; }
        [NotMapped]
        public byte[] File { get; set; }
        public int ObjectId { get; set; }
        public Guid StreamId { get; set; }
        public string FileType { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? AttachmentDate { get; set; }

        public virtual Item Item { get; set; }
        public virtual AppUser User { get; set; }
    }
}
