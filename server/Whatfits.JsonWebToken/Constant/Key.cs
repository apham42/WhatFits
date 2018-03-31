using System;
using Whatfits.Hash;

namespace Whatfits.JsonWebToken.Constant
{
    public static class Key
    {
        // JWT secret key
        private const string SSOsecret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        
        // getter for secret key in bytes
        public static byte[] ssosecret
        {
            get { return Convert.FromBase64String(SSOsecret); }
        }
        
        public static byte[] GetSecret
        {
            get
            {
                HMAC256 createnewsecret = new HMAC256();
                return Convert.FromBase64String(createnewsecret.GenerateSalt());
            }
        }


        
    }
}
