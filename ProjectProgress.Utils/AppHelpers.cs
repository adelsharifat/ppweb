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
            public static string Hash(string value, string salt = "")
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
                data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
                return Convert.ToBase64String(data);
            }
        }
    }
}
