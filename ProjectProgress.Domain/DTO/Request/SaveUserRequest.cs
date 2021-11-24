using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class SaveUserRequest
    {
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    }
}
