
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Utils
{
    public static class Passwords
    {
       public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
        public static bool VerifyPassword(string password,string hashedPassword)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return verified;
        }
    }
}
