using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace UnitTests.UserManagementTest
{
    public class UserManagementGatewayTests
    {
        private UserManagementGateway userMan = new UserManagementGateway();

        [Fact]
        public void DoesUserNameExistsTest()
        {
            // Arrange
            // Searching for amay who already exists in the database
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay"
            };
            // Act
            var response = userMan.DoesUserNameExists(SearchName);
            // Assert
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public void EnableUserTest()
        {
            // Arrange
            // User is already Banned in Database, this will unbanned them
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay",
            };
            // Act
            var response = userMan.EnableUser(SearchName);
            // Assert
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public void DisableUserTest()
        {
            // User is already Unbanned in Database, this will banned them
            UserManagementDTO SearchName = new UserManagementDTO()
            {
                UserName = "amay",
            };
            // Act
            var response = userMan.DisableUser(SearchName);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditFirstName(nameChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditLastname(nameChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditPassword(nameChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditLocation(locationChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditSkillLevel(skillChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditGender(genderChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditProfilePicture(profilePictureChange);
            // Assert
            Assert.True(response.IsSuccessful);
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
            // Act
            var response = userMan.EditDescription(descriptionChange);
            // Assert
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public void DeleteUserTest()
        {
            // Arrange
            UserManagementDTO deleteUser = new UserManagementDTO()
            {
                UserName = "TestUser1"
            };
            // Act
            var response = userMan.DeleteUser(deleteUser);
            var responsefailure = userMan.DoesUserNameExists(deleteUser);
            // Assert
            Assert.False(responsefailure.Data);
        }
    }
}
