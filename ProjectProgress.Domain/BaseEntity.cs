using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            this.CreatedDate = DateTime.Now;
        }
        public T Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public class BaseEntity:BaseEntity<int>
    {

    }
}
