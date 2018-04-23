using System;
using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.CoreDTOs
{
    public class LoginDTO : ICredential,ISalt,ITokenList
    {
        // UserData
        public int UserID { get; set; }

        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        // Salt for hash
        public string SaltValue { get; set; }

        // Security Q&A
        public Dictionary<int, String> Answers { get; set; }
        public Dictionary<int, String> Questions { get; set; }

        // Token
        public string Token { get; set; }
        public int TokenID { get; set; }

        // Token Salt
        public string Salt { get; set; }
    }
}
