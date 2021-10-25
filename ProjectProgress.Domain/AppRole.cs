using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain
{
    public class AppRole:BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
