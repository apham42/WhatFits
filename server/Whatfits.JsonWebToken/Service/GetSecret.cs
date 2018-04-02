using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace Whatfits.JsonWebToken.Service
{
    /// <summary>
    /// Get secret from db
    /// </summary>
    public class GetSecret
    {
        /// <summary>
        /// get secret from db with username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>returns secret that signed the jwt</returns>
        public string UsersSecret(string username)
        {
            // gateway
            LoginGateway auth = new LoginGateway();

            //dto to find secret by username
            LoginDTO dto = new LoginDTO()
            {
                UserName = username
            };

            // response dto
            ResponseDTO<string> response = auth.GetSaltFromTokenList(dto);

            // return secret
            return response.Data;
        }

    }
}
