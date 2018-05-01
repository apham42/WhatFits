using System;
using System.Text;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.Hash;

namespace Whatfits.JsonWebToken.Constant
{
    public class Key
    {
        // JWT secret key
        private const string SSOsecret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        
        // getter for secret key in bytes
        public byte[] ssosecret
        {
            get { return Encoding.UTF8.GetBytes(SSOsecret); }
        }
        
        public byte[] CreateSecret
        {
            get
            {
                HMAC256 createnewsecret = new HMAC256();
                return Convert.FromBase64String(createnewsecret.GenerateSalt());
            }
        }
    }
}
