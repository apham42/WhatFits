using server.Controllers;
using System;
using System.Collections.Generic;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using System.Net.Http;
using System.Web.Http;
using Xunit;
using System.Web.Http.Results;
using server.Model.Account;
using server.Model.Location;

namespace UnitTests.UserManagementTest
{
    /// <summary>
    /// Tests the controller actions inside UserManagementController
    /// </summary>
    public class UserManagementControllerTest
    {
        /// <summary>
        /// Tests if DeleteUser works.
        /// </summary>
        [Fact]
        public void DeleteUser()
        {
            // Arrange
            var controller = new UserManagementController();
            // Creating mock DTO
            UserManagementDTO obj = new UserManagementDTO()
            {
                UserName = "TestUser"
            };
            // Act
            IHttpActionResult actionResult = controller.DeleteUser(obj);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(contentResult.Content);
            Assert.Equal("Success: Account was deleted for amay", contentResult.Content);
        }
        /// <summary>
        /// Tests if EnableUser works
        /// </summary>
        [Fact]
        public void EnableUser()
        {
            // Arrange
            var controller = new UserManagementController();
            UserManagementDTO obj = new UserManagementDTO()
            {
                UserName = "amay"
            };
            // Act
            IHttpActionResult actionResult = controller.EnableUser(obj);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.Equal("Success: Account was deleted for amay", contentResult.Content);
        }
        /// <summary>
        /// Tests if DisableUser works
        /// </summary>
        [Fact]
        public void DisableUser()
        {
            // Arrange
            var controller = new UserManagementController();
            UserManagementDTO obj = new UserManagementDTO()
            {
                UserName = "amay"
            };
            // Act
            IHttpActionResult actionResult = controller.DisableUser(obj);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.Equal("Success: Account was deleted for amay", contentResult.Content);
        }
        /// <summary>
        /// Tests if CreateAdmin works
        /// </summary>
        [Fact]
        public void CreateAdmin()
        {
            // Arrange
            var controller = new UserManagementController();
            UserCredential credentials = new UserCredential("ControllerTestUser", "Password123");
            Address address = new Address("321 W. 119th St.", "Los Angeles", "California", "90061");
            List<SecurityQuestion> SecurityQandAs = new List<SecurityQuestion>();
            SecurityQandAs.Add(new SecurityQuestion("Who was the company you first worked for?", "This is an Answer to 1"));
            SecurityQandAs.Add(new SecurityQuestion("What is your favorite song?", "This is an Answer to 2"));
            SecurityQandAs.Add(new SecurityQuestion("What was the name of your first crush?", "This is an Answer to 3"));
            RegInfo obj = new RegInfo()
            {
                UserCredInfo = credentials,
                UserLocation = address,
                SecurityQandAs = SecurityQandAs
            };
            // Act
            IHttpActionResult actionResult = controller.CreateAdmin(obj);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.Equal("Success: Account was deleted for amay", contentResult.Content);
        }
    }
}
