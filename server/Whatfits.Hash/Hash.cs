using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Whatfits.Hash
{
    public class Hash
    {
        public static string GenerateSalt()
        {
            // Empty salt array
            byte[] salt = new byte[32];

            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }

        public static string HashValue(string original, string salt)
        {
            string hash = original;
            return hash;
        }
    }
}
