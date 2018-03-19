using System;
using System.Collections.Generic;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Xunit;
using System.Security.Claims;

namespace Gateway.Tester
{
    /// <summary>
    /// FileName: RegistrationTests
    /// Description: This is a test of the Registration Gateway.
    /// Purpose: Tests RegisterUser and DoesUserNameExists.
    /// </summary>
    public class RegistrationTests
    {
        // Creating Registration Gateway for testing
        public RegistrationGateway reg = new RegistrationGateway();

        [Fact]
        public void TestAddUser()
        {
            RegistrationDTO usr = new RegistrationDTO()
            {
                // Creating User Table Data
                FirstName = "Test",
                LastName = "User",
                Email = "Example53@example.com",
                Gender = "Male",
                Description = "TestUserDescriptions",
                SkillLevel = "Noob",
                ProfilePicture = null,

                // Creating Credential Table Data
                UserName = "TestUser55",
                Password = "password123",
                Type = "General",

                // Creating Location Data
                Address = "123 Fake St.",
                City = "Los Angeles",
                State = "California",
                Zipcode = "90012",
                Longitude = "NULL",
                Latitude = "NULL",

                // Creating Salt Data
                Salt = "asdfasfasdfa",

                // Creating Security Questions and Answers
                QuestionIDs = new List<int> { 1, 2, 3 },
                Answers = new List<string> { "First Answer to Q1", "Second Answer to Q2", "Third Answer to Q3." },

                // Creating UserClaims
                ClaimIDs = new List<int> { 1, 2, 3 }

            };

            // Passing DTO to gateway to be processed and stored
            reg.RegisterFullUser(usr);
            // Finding UserID by Name that is stored
            Boolean found = reg.DoesUserNameExists(usr);
            Assert.True(found);
        }

        [Fact]
        public void DoesUserNameExistsTest()
        {
            // UserName amay exists in database
            RegistrationDTO SearchName = new RegistrationDTO()
            {
                UserName = "amay"
            };
            Boolean result = reg.DoesUserNameExists(SearchName);
            Assert.True(result);
        }
        [Fact]
        public void GetUserListTest()
        {
            reg.GetUserList();
            Assert.True(true);
        }
    }
}
