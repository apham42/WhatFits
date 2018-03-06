using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Whatfits.DataAccess.Gateways;
using Whatfits.DataAccess.DataTransferObjects.RegistrationDTOs;

namespace Gateway.Tests
{
    public class RegistrationTest
    {
        public RegistrationGateway reg = new RegistrationGateway();
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4,Add(2,2));
        }
        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5,Add(2,2));
        }
        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void TestAddUser()
        {
            RegistrationDTO usr = new RegistrationDTO();
            // I think this is irrelevant
            // usr.SetID(0002);
            // Setting up a User with basic information plus credentials
            usr.SetFirstName("Albert");
            usr.SetLastName("Jones");
            usr.SetEmail("Example@example.com");
            usr.SetIsDisabled(false);
            usr.SetParialRegistration(false);
            usr.SetGender("Male");
            usr.SetAddress("Address Here");
            usr.SetCity("Los Angeles");
            usr.SetState("California");
            usr.SetZipcode("90061");
            usr.SetSalt("asdf;lkjasdl;fkjad;flkajdsfa");
            usr.SetUserName("TestUser4");
            usr.SetPassword("asdfasdfasdf");
            // Note: I need to store Claims, consult Aaron
            //reg.Create(usr);
            int foundUserID = reg.FindByUserName(userName: "TestUser56");
            string foundUserName = reg.FindByID(foundUserID);
            Assert.Equal("TestUser4",foundUserName);
        }
        [Fact]
        public void TestFindByID()
        {
            //UserID 0003 already exists as JDOE
            string foundName= reg.FindByID(0003);
            Assert.Equal("JDOE",foundName);
        }
        [Fact]
        public void TestFindByUserName()
        {
            // UserName JDOE already exists as UserID 0003
            int foundID = reg.FindByUserName("JDOE");
            Assert.Equal(0003,foundID);
        }
        [Fact]
        public void TestDoesUserExist()
        {
            // Username JDOE already exists in Database
            Assert.True(reg.DoesUserNameExist("JDOE"));
        }
    }
}
