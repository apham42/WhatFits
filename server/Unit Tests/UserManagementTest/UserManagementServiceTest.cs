using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using server.Services;
using server.Model.Account;
using server.Model.Location;

namespace UnitTests.UserManagementTest
{
    public class UserManagementServiceTest
    {
        [Fact]
        public void DisableUser()
        {
            // Arrange
            UserManagementService service = new UserManagementService();
            UserManagementDTO obj = new UserManagementDTO()
            {
                UserName = "rstrong"
            };
            // Act
            var response = service.DisableUser(obj);
            // Assert
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public void EnableUser()
        {
            // Arrange
            UserManagementService service = new UserManagementService();
            UserManagementDTO obj = new UserManagementDTO()
            {
                UserName = "rstrong"
            };
            // Act
            var response = service.EnableUser(obj);
            // Assert
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public void DeleteUser()
        {
            // Arrange
            UserManagementService service = new UserManagementService();
            UserManagementDTO obj = new UserManagementDTO()
            {
                UserName = "latmey"
            };
            // Act
            var response = service.DeleteUser(obj);
            // Assert
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public void CreateAdmin()
        {
            // Arrange
            AccountService service = new AccountService();
            UserCredential credentials = new UserCredential("ServiceTestUser","Password123");
            Address address = new Address("321 W. 119th St.","Los Angeles","California","90061");
            List<SecurityQuestion> SecurityQandAs = new List<SecurityQuestion>();
            SecurityQandAs.Add(new SecurityQuestion("Who was the company you first worked for?", "This is an Answer to 1"));
            SecurityQandAs.Add(new SecurityQuestion("What is your favorite song?", "This is an Answer to 2"));
            SecurityQandAs.Add(new SecurityQuestion("What was the name of your first crush?", "This is an Answer to 3"));
            RegInfo obj = new RegInfo()
            {
                UserCredInfo = credentials,
                UserLocation = address,
                UserType = "Enable",
                SecurityQandAs = SecurityQandAs
            };
            // Act
            var response = service.RegisterAdmin(obj);
            // Assert
            Assert.True(response.isSuccessful);
        }
    }
}
