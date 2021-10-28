using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectProgress.Domain
{
    public class Item:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Item GetItem { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}
