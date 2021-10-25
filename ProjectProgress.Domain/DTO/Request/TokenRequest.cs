using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Request
{
    public class TokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
