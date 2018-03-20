using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Whatfits.DataAccess.DTOs.CoreDTOs
{
    public class LoginDTO
    {
        // UserData
        public int UserID { get; set; }
        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        // Salt
        public string Salt { get; set; }
        // Security Q&A
        public Dictionary<int, String> Answers { get; set; }
        public Dictionary<int, String> Questions { get; set; }
        // Token
        public string Token { get; set; }
        public int TokenID { get; set; }
    }
}
