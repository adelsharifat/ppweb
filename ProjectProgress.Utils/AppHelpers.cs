using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProjectProgress.Utils
{
    public static class AppHelpers
    {
        public static class BCrypt
        {
            public static string GenerateSalt(int nSalt)
            {
                var saltBytes = new byte[nSalt];

                using (var provider = new RNGCryptoServiceProvider())
                {
                    provider.GetNonZeroBytes(saltBytes);
                }

                return Convert.ToBase64String(saltBytes);
            }

            public static string HashPassword(string password, string salt, int nIterations, int nHash)
            {
                var saltBytes = Convert.FromBase64String(salt);

                using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
                {
                    return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
                }
            }

            public static bool Verify(string providerPassword, string hashedPassword,string salt, int nIterations, int nHash)
            {
                if (HashPassword(providerPassword,salt, nIterations,nHash) == hashedPassword) return true;
                return false;
            }
        }
    }
}
