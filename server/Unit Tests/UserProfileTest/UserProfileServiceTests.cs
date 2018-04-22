using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using server.Business_Logic.Services;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;

namespace UnitTests.UserProfileTest
{
    public class UserProfileServiceTests
    {
        [Fact]
        public void GetProfileTest()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            UsernameDTO obj = new UsernameDTO()
            {
                Username = "amay"
            };
            // Act
            var response = service.GetProfile(obj);
            // Assert
            Assert.True(response.IsSuccessful);
            Assert.Equal("April", response.Data.FirstName);
            Assert.Equal("May", response.Data.LastName);
            Assert.Equal("Female", response.Data.Gender);
            Assert.Equal("Beginner", response.Data.SkillLevel);
            Assert.Equal("SomeDescription", response.Data.Description);
            Assert.Null(response.Data.ProfilePicture);
        }
        [Fact]
        public void EditProfileTest()
        {
            // Arrange
            UserProfileService service = new UserProfileService();
            ProfileDTO obj = new ProfileDTO()
            {
                UserName = "amay",
                FirstName = "John",
                LastName = "Smith",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis nunc ac arcu congue luctus. Nulla ligula sapien, sodales fringilla ligula sit amet, gravida sagittis turpis. Nunc tincidunt est vel risus lobortis laoreet. Suspendisse feugiat metus ac egestas tempor.",
                SkillLevel = "Advance",
                Gender = "Male",
                ProfilePicture = "../../assets/Images/ProfileDummy/profilePicture.jpg"
            };
            // Act
            var response = service.EditProfile(obj);
            // Assert
            Assert.True(response.IsSuccessful);
        }
    }
}
