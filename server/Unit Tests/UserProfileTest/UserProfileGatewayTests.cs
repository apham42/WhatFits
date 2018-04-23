using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Xunit;

namespace UnitTests.UserProfileTest
{
    public class UserProfileGatewayTests
    {
        [Fact]
        public void GetUserProfileGatewayTest()
        {
            // Arrange
            UserProfileGateway temp = new UserProfileGateway();
            UsernameDTO obj = new UsernameDTO()
            {
                Username = "amay"
            };
            // Act
            var response = temp.GetProfile(obj);
            // Assert
            Assert.True(response.IsSuccessful);
            Assert.Equal("April",response.Data.FirstName);
            Assert.Equal("May", response.Data.LastName);
            Assert.Equal("Female", response.Data.Gender);
            Assert.Equal("Beginner",response.Data.SkillLevel);
            Assert.Equal("SomeDescription", response.Data.Description);
            Assert.Null(response.Data.ProfilePicture);
        }
        [Fact]
        public void EditProfileTest()
        {
            // Arrange
            UserProfileGateway temp = new UserProfileGateway();
            /*
            ProfileDTO obj = new ProfileDTO()
            {
                UserName = "rsanchez92",
                FirstName = "aasdf",
                LastName = "dfegv",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis nunc ac arcu congue luctus. Nulla ligula sapien, sodales fringilla ligula sit amet, gravida sagittis turpis. Nunc tincidunt est vel risus lobortis laoreet. Suspendisse feugiat metus ac egestas tempor.",
                SkillLevel = "Advance",
                Gender = "Male",
                ProfilePicture = "../../assets/Images/ProfileDummy/profilePicture.jpg"            
            };*/
            // Act
            var response = temp.EditProfile(obj);
            // Assert
            Assert.True(response.IsSuccessful);
        }
    }
}
