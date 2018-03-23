using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Whatfits.Hash
{
    /// <summary>
    /// Can create a salt and hash a value
    /// </summary>
    public class HMAC256
    {
        public HMAC256()
        {

        }
        
        /// <summary>
        /// Generates a random salt value
        /// </summary>
        /// <returns> salt </returns>
        public string GenerateSalt()
        {
            // Empty salt array
            byte[] salt = new byte[32];
            string generatedSalt;
            string result;
            try
            {
                using (var random = new RNGCryptoServiceProvider())
                {
                    random.GetNonZeroBytes(salt);
                }

                generatedSalt = Convert.ToBase64String(salt);
                result = generatedSalt;
                return result;

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

        /// <summary>
        /// Generates a hash based on the original value and salt of the dto
        /// </summary>
        /// <param name="dto"> DTO that contains original value and a salt </param>
        /// <returns> hashed value </returns>
        public string Hash(HashDTO dto)
        {
            // changes the hashDTO original to bytes
            string result;

            try
            {
                byte[] convertedOriginal = Encoding.ASCII.GetBytes(dto.Original + dto.Salt);


                // creates the hash in bytes based on the converted original
                using (SHA256Cng sha256 = new SHA256Cng())
                {
                    byte[] hash = sha256.ComputeHash(convertedOriginal);

                    //converts back to string
                    result = Encoding.ASCII.GetString(hash);
                }
                return result;
            }
            catch (EncoderFallbackException)
            {
                return "";
            }
            catch (ObjectDisposedException)
            {
                return "";
            }
            catch (ArgumentException)
            {
                return "";
            }
        }
    }
}
