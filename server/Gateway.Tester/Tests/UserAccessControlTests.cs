using System;
using System.Collections.Generic;
using Xunit;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System.Security.Claims;
namespace Gateway.Tester
{
    /// <summary>
    /// Tests each method in the UserAccessGateway
    /// </summary>
    public class UserAccessControlTests
    {
        private UserAccessControlGateway uac = new UserAccessControlGateway();
        [Fact]
        public void AddClaimTest()
        {
            UserAccessDTO temp = new UserAccessDTO()
            {
                ClaimItem = new Claim("TestClaimType","TestClaimValue")
            };
            Assert.True(uac.AddUserClaims(temp));
        }
        [Fact]
        public void RemoveClaimTest()
        {
            UserAccessDTO temp = new UserAccessDTO()
            {
                ClaimItem = new Claim("User", "Edit")
            };
            Assert.True(uac.RemoveFromClaimsList(temp));
        }
        [Fact]
        public void GetClaimsListTest()
        {
            List<Claim> temp = new List<Claim>();
            temp = uac.GetClaimsList();
        }
        [Fact]
        public void AddUserClaimTest()
        {
            UserAccessDTO temp = new UserAccessDTO()
            {
                UserName = "amay",
                ClaimID = { 8,3,2 }
            };
            Assert.True(uac.AddUserClaims(temp));
        }
        [Fact]
        public void RemoveUserClaimTest()
        {

        }
        [Fact]
        public void GetUserClaimsTest()
        {

        }
    }
}
