using System;
using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.CoreDTOs
{
    public class UserManagementDTO: IUserProfile, ILocation, ICredential,ISalt
    {
        // UserData
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public string SkillLevel { get; set; }
        public string Type { get; set; }
        
        // Location
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        
        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        
        // UserClaims
        public List<Claim> UserClaims { get; set; }
        
        // Salt
        public string SaltValue { get; set; }

        // Security Q&A
        public Dictionary<int, String> Answers { get; set; }
        public Dictionary<int, String> Questions { get; set; }

        // Token
        public string Token { get; set; }
        
    }
}
