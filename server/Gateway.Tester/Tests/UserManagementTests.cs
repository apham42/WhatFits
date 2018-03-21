using System;
using System.Collections.Generic;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;
using System.Security.Claims;

namespace Gateway.Tester
{
    public class UserManagementTests
    {
        private UserManagementGateway userMan = new UserManagementGateway();

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void TestAddUser()
        {
            UserManagementDTO usr = new UserManagementDTO()
            {
                // Creating User Table Data
                FirstName = "User",
                LastName = "ManTest",
                Email = "Example12@example.com",
                Gender = "Male",
                Description = "TestUserDescriptions",
                SkillLevel = "Expert",
                ProfilePicture = null,

                // Creating Credential Table Data
                UserName = "UserManTest",
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
                UserClaims = new List<Claim>()
                {
                    new Claim("NewClaimType1", "NewClaimValue1"),
                    new Claim("NewClaimType2", "NewClaimValue2"),
                    new Claim("NewClaimType3", "NewClaimValue3"),
                }
            };

            // Passing DTO to gateway to be processed and stored
            userMan.RegisterFullUser(usr);
            // Finding UserID by Name that is stored
            Boolean found = userMan.DoesUserNameExists(usr);
            Assert.True(found);
        }

        [Fact]
        public void DoesUserNameExistsTest()
        {
            // UserName amay exists in database
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay"
            };
            Boolean result = userMan.DoesUserNameExists(SearchName);
            Assert.True(result);
        }

        [Fact]
        public void EnableUserTest()
        {
            // User is already Banned in Database, this will unbanned them
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay",

            };
            Boolean result = userMan.EnableUser(SearchName);
            Assert.True(result);
        }

        [Fact]
        public void DisableUserTest()
        {
            // User is already Unbanned in Database, this will banned them
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "rstrong",
            };
            Boolean result = userMan.DisableUser(SearchName);
            Assert.True(result);
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
            Boolean result = userMan.EditFirstName(nameChange);
            Assert.True(result);
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
            Boolean result = userMan.EditLastname(nameChange);
            Assert.True(result);
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
            Boolean result = userMan.EditPassword(nameChange);
            Assert.True(result);
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
            Boolean result = userMan.EditLocation(locationChange);
            Assert.True(result);
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
            Boolean result = userMan.EditSkillLevel(skillChange);
            Assert.True(result);
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
            Boolean result = userMan.EditGender(genderChange);
            Assert.True(result);
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
            Boolean result = userMan.EditProfilePicture(profilePictureChange);
            Assert.True(result);
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
            Boolean result = userMan.EditDescription(profilePictureChange);
            Assert.True(result);
        }
    }
}
