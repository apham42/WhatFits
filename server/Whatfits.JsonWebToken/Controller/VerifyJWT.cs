using System;
using System.Text;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;
using Whatfits.JsonWebToken.Constant;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace Whatfits.JsonWebToken.Controller
{
    public static class VerifyJWT
    {
        public static void VerifyToken(string token, byte[] secret)
        {
        }

        private static bool Verify(string rawSignature, byte[] secret, string signature)
        {
            return signature == Sign(rawSignature, secret);
        }

        private static string Sign(string str, byte[] key)
        {
            var encoding = new ASCIIEncoding();

            byte[] signature;

            using (var crypto = new HMACSHA256(key))
            {
                signature = crypto.ComputeHash(encoding.GetBytes(str));
            }

            return Base64Encode(signature);
        }

        public static string Base64Encode(dynamic obj)
        {
            Type strType = obj.GetType();

            var base64EncodedValue = Convert.ToBase64String(strType.Name.ToLower() == "string" ? Encoding.UTF8.GetBytes(obj) : obj);

            return base64EncodedValue;
        }

        public static dynamic Base64Decode(string str)
        {
            var base64DecodedValue = Convert.FromBase64String(str);

            return base64DecodedValue;
        }
    }
}
