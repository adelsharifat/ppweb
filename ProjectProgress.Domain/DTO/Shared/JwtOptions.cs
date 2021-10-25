using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Shared
{
    public class JwtOptions
    {
        public string SecKey { get; set; } = "cmis@cmissdlfkhsdfqweuqiwsldkjfhdsaka";
        public string EncKey { get; set; } = "0123456789123456";
        public int Expire { get; set; } = 10;
        public int RefreshTokenExpire { get; set; } = 7;
        public int Sckew { get; set; }
        public string Issuer { get; set; } = null;
        public string Audience { get; set; } = null;
    }
}
