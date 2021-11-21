using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class ItemAddRequest
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
    }
}
