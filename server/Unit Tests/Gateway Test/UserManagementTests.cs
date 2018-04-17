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
                UserName = "rstrong",

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
            UserManagementDTO descriptionChange = new UserManagementDTO()
            {
                UserName = "amay",
                Description = "Edited Description"
            };
            ResponseDTO<Boolean> found = userMan.EditDescription(descriptionChange);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void DeleteUserTest()
        {
            UserManagementDTO deleteUser = new UserManagementDTO()
            {
                UserName = "amay"
            };
            ResponseDTO<Boolean> found = userMan.DeleteUser(deleteUser);
            ResponseDTO<Boolean> found2 = userMan.DoesUserNameExists(deleteUser);
            Assert.False(found2.Data);
        }
    }
}
