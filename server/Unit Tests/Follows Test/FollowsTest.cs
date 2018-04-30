using Xunit;
using server.Controllers;
using Microsoft.Web.WebSockets;
using server.Business_Logic.Services;
using System.Web.Script.Serialization;
using Whatfits.Models.Models;

namespace FollowsTest
{
    public class FollowsTest
    {
        FollowsService followsService = new FollowsService();
        [Fact]
        public void Follow()
        {
            var response = followsService.Add("chattest1", "chattest5");
            Assert.True(response);
        }

        [Fact]
        public void UnFollow()
        {
            var response = followsService.Add("chattest1", "chattest5");
            Assert.True(response);
        }

        [Fact]
        public void IsFollow()
        {
            var response = followsService.Add("chattest1", "chattest5");
            Assert.True(response);
        }

        [Fact]
        public void GetFollows()
        {
            var response = followsService.GetEnumerator("chattest1");
            bool success = false;
            if (response != null)
            {
                success = true;
            }
            Assert.True(success);
        }
    }
}
