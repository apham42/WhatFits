using System;
using System.Text;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Whatfits.JsonWebToken.Controller
{
    class VerifyJWT
    {
        public static string EncodeToken(JwtPayload jwtPayload, string secret)
        {
            JwtHeader header = new JwtHeader();
            header.Add("Type", "JWT");
            header.Add("Alg", "HS256");


            var jwt = Base64Encode(JsonConvert.SerializeObject(header)) + "." + Base64Encode(JsonConvert.SerializeObject(jwtPayload));

            jwt += "." + Sign(jwt, secret);

            return jwt;
        }

        public static JwtPayload DecodeToken(string token, string secret)
        {
            string[] segments = token.Split('.');

            if (segments.Length != 3)
                throw new Exception("Token structure is incorrect!");

            JwtHeader header = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Base64Decode(segments[0])), typeof(JwtHeader));
            JwtPayload jwtPayload = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Base64Decode(segments[1])), typeof(JwtPayload));

            var rawSignature = segments[0] + '.' + segments[1];

            if (!Verify(rawSignature, secret, segments[2]))
                throw new Exception("Verification Failed");

            return jwtPayload;
        }

        private static bool Verify(string rawSignature, string secret, string signature)
        {
            return signature == Sign(rawSignature, secret);
        }

        private static string Sign(string str, string key)
        {
            var encoding = new ASCIIEncoding();

            byte[] signature;

            using (var crypto = new HMACSHA256(encoding.GetBytes(key)))
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
