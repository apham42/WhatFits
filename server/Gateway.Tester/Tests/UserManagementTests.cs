using System;
using System.Collections.Generic;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using Xunit;
using System.Security.Claims;

namespace Gateway.Tester
{
    public class UserManagementTests
    {
        private UserManagementGateway userMan = new UserManagementGateway();
        [Fact]
        public void RegisterFullUser()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            temp.Add(1, "Answer to Q1");
            temp.Add(2, "Answer to Q2");
            temp.Add(3, "Answer to Q3");
            List<Claim> claims = new List<Claim>()
            {
                    new Claim("NewClaimType1", "NewClaimValue1"),
                    new Claim("NewClaimType2", "NewClaimValue2"),
                    new Claim("NewClaimType3", "NewClaimValue3"),
            };
            UserManagementDTO usr = new UserManagementDTO()
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
                SaltValue = "asdfasfasdfa",

                // Creating Security Questions and Answers
                Answers = temp,

                // Creating UserClaims
                UserClaims = claims
            };

            // Passing DTO to gateway to be processed and stored
            userMan.RegisterFullUser(usr);
            // Finding UserID by Name that is stored
            ResponseDTO<Boolean> found = userMan.DoesUserNameExists(usr);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void DoesUserNameExistsTest()
        {
            // UserName amay exists in database
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay"
            };
            ResponseDTO<Boolean> found = userMan.DoesUserNameExists(SearchName);
            Assert.True(found.IsSuccessful);
        }

        [Fact]
        public void EnableUserTest()
        {
            // User is already Banned in Database, this will unbanned them
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay",

            };
            ResponseDTO<Boolean> found = userMan.EnableUser(SearchName);
            Assert.True(found.IsSuccessful);
        }

        [Fact]
        public void DisableUserTest()
        {
            // User is already Unbanned in Database, this will banned them
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "rstrong",
            };
            ResponseDTO<Boolean> found = userMan.DisableUser(SearchName);
            Assert.True(found.IsSuccessful);
        }

        [Fact]
        public void EditFirstNameTest()
        {
            // User First Name is April, this test will change it to March
            UserManagementDTO nameChange = new UserManagementDTO()
            {
                UserName = "amay",
                FirstName = "March"

            };
            ResponseDTO<Boolean> found = userMan.EditFirstName(nameChange);
            Assert.True(found.IsSuccessful);
        }

        [Fact]
        public void EditLastNameTest()
        {
            // User Last Name is May, this test will change it to March
            UserManagementDTO nameChange = new UserManagementDTO()
            {
                UserName = "amay",
                LastName = "September"

            };
            ResponseDTO<Boolean> found = userMan.EditLastname(nameChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void EditPasswordTest()
        {
            // User password is 
            UserManagementDTO nameChange = new UserManagementDTO()
            {
                UserName = "amay",
                Password = "Edited Password"

            };
            ResponseDTO<Boolean> found = userMan.EditPassword(nameChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void EditLocationTest()
        {
            // User First Name is April, this test will change it to March
            UserManagementDTO locationChange = new UserManagementDTO()
            {
                UserName = "amay",
                Address = "Edited Address",
                City = "Edited City",
                State = "Edited State",
                Zipcode = "Edited City"
            };
            ResponseDTO<Boolean> found = userMan.EditLocation(locationChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void EditSkillLevelTest()
        {
            // User First Name is April, this test will change it to March
            UserManagementDTO skillChange = new UserManagementDTO()
            {
                UserName = "amay",
                SkillLevel = "Edited Skill Level"
            };
            ResponseDTO<Boolean> found = userMan.EditSkillLevel(skillChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void EditGenderTest()
        {
            // User First Name is April, this test will change it to March
            UserManagementDTO genderChange = new UserManagementDTO()
            {
                UserName = "amay",
                Gender = "Edited Gender"
            };
            ResponseDTO<Boolean> found = userMan.EditGender(genderChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void EditProfilePictureTest()
        {
            // User First Name is April, this test will change it to March
            UserManagementDTO profilePictureChange = new UserManagementDTO()
            {
                UserName = "amay",
                ProfilePicture = "Directory",
            };
            ResponseDTO<Boolean> found = userMan.EditProfilePicture(profilePictureChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void EditDescriptionTest()
        {
            // User First Name is April, this test will change it to March
            UserManagementDTO profilePictureChange = new UserManagementDTO()
            {
                UserName = "amay",
                Description = "Edited Description"
            };
            ResponseDTO<Boolean> found = userMan.EditDescription(profilePictureChange);
            Assert.True(found.IsSuccessful);
        }
    }
}
