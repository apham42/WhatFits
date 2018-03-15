using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using server.Model.Data_Transfer_Objects.SecurityDTO_s;

namespace Whatfits.Hash
{
    public class Hash
    {
        public SaltResponseDTO GenerateSalt()
        {
            // Empty salt array
            byte[] salt = new byte[32];
            SaltResponseDTO result = new SaltResponseDTO();

            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            // Return the string encoded salt
            result.Salt = Convert.ToBase64String(salt);
            
            // Sets the response DTO message and status based on result
            if (result.Salt != null || result.Salt.Equals(""))
            {
                result.Status = false;
                result.Message = HashConstants.SALT_ERROR;
            }
            else
            {
                result.Status = true;
                result.Message = HashConstants.SALT_VALID;
            }

            return result;
            
        }

        public HashResponseDTO HashValue(HashDTO dto)
        {
            HashResponseDTO result = new HashResponseDTO();

            // changes the hashDTO original to bytes
            byte[] convertedOriginal = Encoding.ASCII.GetBytes(dto.Original);

            // creates the hash in bytes based on the converted original
            using ( SHA256Cng sha256 = new SHA256Cng() )
            {
                byte[] hash = sha256.ComputeHash(convertedOriginal);

                //converts back to string
                result.Hash = Encoding.ASCII.GetString(hash);
            }

            // Sets the response DTO message and status based on result
            if (result.Hash != null || result.Hash.Equals(""))
            {
                result.Status = false;
                result.Message = HashConstants.HASH_ERROR;
            }
            else
            {
                result.Status = true;
                result.Message = HashConstants.HASH_VALID;
            }

            return result;
        }
    }
}
