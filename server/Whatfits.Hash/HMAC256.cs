using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Whatfits.Hash
{
    public class HMAC256
    {
        public string GenerateSalt()
        {
            // Empty salt array
            byte[] salt = new byte[32];
            string generatedSalt;
            string result = "";
            try
            {
                using (var random = new RNGCryptoServiceProvider())
                {
                    random.GetNonZeroBytes(salt);
                }

                generatedSalt = Convert.ToBase64String(salt);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (CryptographicException)
            {
                throw;
            }

            return result;
            
        }

        public string Hash(HashDTO dto)
        {
            // changes the hashDTO original to bytes
            string result;

            try
            {
                byte[] convertedOriginal = Encoding.ASCII.GetBytes(dto.Original);


                // creates the hash in bytes based on the converted original
                using (SHA256Cng sha256 = new SHA256Cng())
                {
                    byte[] hash = sha256.ComputeHash(convertedOriginal);

                    //converts back to string
                    result = Encoding.ASCII.GetString(hash);
                }
            }
            catch (EncoderFallbackException)
            {
                throw;
            }
            catch (ObjectDisposedException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            

            return result;
        }
    }
}
