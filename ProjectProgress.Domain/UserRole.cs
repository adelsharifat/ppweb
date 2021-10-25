using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual AppRole Role{ get; set; }
    }
}
