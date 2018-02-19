using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using server.Controllers;
namespace Gateways.UnitTests
{
    
    public class User
    {
        public int UserID;
        public string Email;
        public string FirstName;
        public string LastName;
        public string Gender;
    }
    
    [TestClass]
    public class UserControllerUnitTest
    {
        [TestMethod]
        public void TestCreate()
        {
            //   Assert.AreEqual("HomeController","HomeController");
            UserController controllerUnderTest = new UserController();
            User usr = new User();
            usr.UserID = 777;
            usr.Email = "asdf@live.com";
            usr.FirstName = "TestUser";
            usr.LastName = "TestUserLastName";
            usr.Gender = "Male";
            string output = JsonConvert.SerializeObject(usr);
            var result = controllerUnderTest.Create() as ViewResult;
            Assert.AreEqual("fooview",result.ViewName);
        }
    }
}
