using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
