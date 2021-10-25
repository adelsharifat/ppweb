using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectProgress.Domain
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string EnName { get; set; }
        public int? ParentId { get; set; }
    }
}
