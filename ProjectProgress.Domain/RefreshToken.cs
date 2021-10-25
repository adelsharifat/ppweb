using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain
{
    public class RefreshToken:BaseEntity
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; } = false;
        public DateTime? Revoked { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
        public bool IsActive => Revoked == null && !IsExpired;
        public string CreatedByIp { get; set; }
        public string RevokedByIp { get; set; }
        public virtual AppUser User { get; set; }
    }
}
