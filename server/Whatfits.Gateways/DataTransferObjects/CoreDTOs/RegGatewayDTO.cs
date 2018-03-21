using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    /// <summary>
    /// RegistrationDTO
    /// PURPOSE: Contains all data required to register a user.
    /// </summary>
    public class RegGatewayDTO
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
        public string Type { get; set; }
        // UserClaims
        public List<Claim> UserClaims { get; set; }
        // Salt
        public string Salt { get; set; }
        // Security Q&A
        public List<int> QuestionIDs { get; set; }
        public List<String> Answers { get; set; }

    }
}
