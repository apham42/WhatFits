using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Hash
{
    /// <summary>
    /// Hashes a string with the SHA1 Hashing Algorithm
    /// </summary>
    public class SHA1CNG
    {
        public SHA1CNG()
        {

        }
        /// <summary>
        /// Takes a string and returns the hash of it.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public string Hash(string payload)
        {
            string hashedString = "";
            try
            {
                using (var hasher = new SHA1Cng())
                {
                    hashedString = BitConverter.ToString(hasher.ComputeHash(Encoding.UTF8.GetBytes(payload)));
                    hashedString = hashedString.Replace("-", "");
                }
                return hashedString;
            }
            catch (ArgumentNullException)
            {
                return "";
            }
            catch (CryptographicException)
            {
                return "";
            }
        }
    }
}
