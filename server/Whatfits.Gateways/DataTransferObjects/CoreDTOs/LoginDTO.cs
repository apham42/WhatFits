using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    public class LoginDTO
    {
        // UserData
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsFullyRegistered { get; set; }
        public Boolean IsBanned { get; set; }
        // UserClaims
        public List<int> ClaimIDs { get; set; }
        public List<Claim> UserClaims { get; set; }
        // Salt
        public string Salt { get; set; }
        // Security Q&A
        public Dictionary<int, String> Answers { get; set; }
        public Dictionary<int, String> Questions { get; set; }
    }
}
