﻿using System;
using System.Collections.Generic;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    /// <summary>
    /// RegistrationDTO
    /// PURPOSE: Contains all data required to register a user.
    /// </summary>
    public class RegistrationDTO
    {
        // UserData
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string SkillLevel { get; set; }
        // Location
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsFullyRegistered { get; set; }
        public Boolean IsBanned { get; set; }
        // UserClaims
        public List<int> ClaimIDs { get; set; }
        // Salt
        public string Salt { get; set; }
        // Security Q&A
        public List<int> QuestionIDs { get; set; }
        public List<String> Answers { get; set; }

    }
}
