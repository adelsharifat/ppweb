using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectProgress.Domain
{
    public class Item:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsDelete { get; set; } = false;

        [NotMapped]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [NotMapped]
        public virtual AppUser User { get; set; }
        [NotMapped]
        public virtual Item GetItem { get; set; }
        [NotMapped]
        public virtual ICollection<Item> Items { get; set; }

    }
}
