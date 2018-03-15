using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.JsonWebToken.Constant
{
    class Key
    {
        // JWT secret key
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        // getter for secret key
        public static string secret
        {
            get { return Secret; }
        }

        // create string into base 64
        //public static byte[] getBytes(string input)
        //{
        //    var bytes = new byte[input.Length * sizeof(char)];
        //    Buffer.BlockCopy(input.ToCharArray(), 0, bytes, 0, bytes.Length);

        //    return bytes;
        //}
    }
}
