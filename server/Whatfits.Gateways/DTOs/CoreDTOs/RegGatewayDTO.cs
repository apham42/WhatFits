using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    /// <summary>
    /// Contains the registration information that is needed to 
    /// create a user in the database
    /// </summary>
    public class RegGatewayDTO
    {
        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        // Location
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        // UserClaims
        public List<Claim> UserClaims { get; set; }
        // Salt
        public string Salt { get; set; }
        // Security Q&A
        public List<string> Questions { get; set; }
        public List<string> Answers { get; set; }
    }
}
