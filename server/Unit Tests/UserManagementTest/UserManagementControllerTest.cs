using server.Controllers;
using System;
using System.Collections.Generic;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using System.Net.Http;
using System.Web.Http;
using Xunit;
using System.Web.Http.Results;

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
            UserManagementDTO temp = new UserManagementDTO()
            {
                UserName = "amay"
            };
            // Act
            IHttpActionResult actionResult = controller.DeleteUser(temp);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            // Assert
            Assert.NotNull(contentResult);
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
            UserManagementDTO temp = new UserManagementDTO()
            {
                UserName = "amay"
            };
            // Act
            IHttpActionResult actionresult = controller.EnableUser(temp);
            // Assert
        }
        /// <summary>
        /// Tests if DisableUser works
        /// </summary>
        [Fact]
        public void DisableUser()
        {
            // Arrange
            // Act
            // Assert
        }
        /// <summary>
        /// Tests if CreateAdmin works
        /// </summary>
        [Fact]
        public void CreateAdmin()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
