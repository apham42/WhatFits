using System.Web.Mvc;
using Newtonsoft.Json;
using server.Controllers;
using Xunit;
using Whatfits.Models;
using Whatfits.Gateways;
namespace Gateways.UnitTests
{  
    public class UserControllerUnitTest
    {
        int Add(int x, int y)
        {
            return x + y;
        }
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2,2));
        }
        
        [Fact]
        public void TestCreateUser()
        {
            UserController controllerUnderTest = new UserController();
            User usr = new User();
            usr.ID = 16;
            usr.Email = "jjjj";
            usr.FirstName = "dfsadfa";
            usr.LastName = "dfasd";
            usr.Gender = "Sdfsdf";
            var result = controllerUnderTest.Create(usr);
            
            Assert.Equal(result,controllerUnderTest.Details(16));
        }
    }
}
