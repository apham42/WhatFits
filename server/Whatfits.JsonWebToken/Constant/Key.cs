using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.JsonWebToken.Constant
{
    public static class Key
    {
        // JWT secret key
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        // getter for secret key
        public static byte[] secret
        {
            get { return Convert.FromBase64String(Secret); }
        }
    }
}
