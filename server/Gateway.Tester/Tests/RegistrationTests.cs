using System;
using System.Collections.Generic;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Xunit;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs;

namespace Gateway.Tester
{
    /// <summary>
    /// FileName: RegistrationTests
    /// Description: This is a test of the Registration Gateway.
    /// Purpose: Tests RegisterUser and DoesUserNameExists.
    /// </summary>
    public class RegistrationTests
    {
        // Creating Registration Gateway for testing
        public RegistrationGateway reg = new RegistrationGateway();

        [Fact]
        public void RegisterFullUser()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            temp.Add(1, "Answer to Q1");
            temp.Add(2, "Answer to Q2");
            temp.Add(3, "Answer to Q3");
            List<Claim> claims = new List<Claim>()
            {
                    new Claim("NewClaimType1", "NewClaimValue1"),
                    new Claim("NewClaimType2", "NewClaimValue2"),
                    new Claim("NewClaimType3", "NewClaimValue3"),
            };
            RegistrationDTO usr = new RegistrationDTO()
            {
                // Creating User Table Data
                FirstName = "Test",
                LastName = "User",
                Email = "Example53@example.com",
                Gender = "Male",
                Description = "TestUserDescriptions",
                SkillLevel = "Noob",
                ProfilePicture = null,

                // Creating Credential Table Data
                UserName = "TestUser55",
                Password = "password123",
                Type = "General",

                // Creating Location Data
                Address = "123 Fake St.",
                City = "Los Angeles",
                State = "California",
                Zipcode = "90012",
                Longitude = "NULL",
                Latitude = "NULL",

                // Creating Salt Data
                Salt = "asdfasfasdfa",

                // Creating Security Questions and Answers
                Answers = temp,

                // Creating UserClaims
                UserClaims = claims
            };

            // Passing DTO to gateway to be processed and stored
            reg.RegisterFullUser(usr);
            // Finding UserID by Name that is stored
            ResponseDTO<Boolean> found = reg.DoesUserNameExists(usr);
            Assert.True(found.IsSuccessful);
        }

        [Fact]
        public void DoesUserNameExistsTest()
        {
            // UserName amay exists in database
            RegistrationDTO SearchName = new RegistrationDTO()
            {
                UserName = "amay"
            };
            ResponseDTO<Boolean> found = reg.DoesUserNameExists(SearchName);
            Assert.True(found.IsSuccessful);
        }
        [Fact]
        public void GetUserListTest()
        {
            // NOTE: Run this first before register user
            List<string> expectedList = new List<string>
            {
                "latmey","amay","rstrong","rblue","chackins"
            };
            ResponseDTO<List<string>> found = reg.GetUserList();
            Assert.Equal(expectedList,found.Data);
        }
        [Fact]
        public void GetSecurityQuestions()
        {
            Dictionary<int, string> expectedDictionary = new Dictionary<int, string>();
            expectedDictionary.Add(1, "Who was the company you first worked for?");
            expectedDictionary.Add(2, "Where did you go to highschool or college?");
            expectedDictionary.Add(3, "What was the name of the teacher who gave you your first failing grade?");
            expectedDictionary.Add(4, "What is your favorite song?");
            expectedDictionary.Add(5, "What is your mother's maiden name?");
            expectedDictionary.Add(6, "What is your favorite sports team?");
            expectedDictionary.Add(7, "What was the name of your first crush?");
            expectedDictionary.Add(8, "What is the first name of the person you first kissed?");
            expectedDictionary.Add(9, "In what city or town does your nearest sibling live?");
            ResponseDTO<Dictionary<int, string>> found = reg.GetSecurityQuestions();
            Assert.Equal(expectedDictionary, found.Data);
        }
        [Fact]
        public void GetSecurityQandAsTest()
        {
            // This is the security questions and answers for UserID = 1 / UserName = latmey
            Dictionary<int, string> expectedDictionary = new Dictionary<int, string>();
            expectedDictionary.Add(1, "Answer to Question 1");
            expectedDictionary.Add(3, "Answer to Question 3");
            expectedDictionary.Add(4, "Answer to Question 4");
            // Creates the request to get security questions and answers
            RegistrationDTO request = new RegistrationDTO()
            {
                UserName = "latmey"
            };
            ResponseDTO<Dictionary<int, string>> found = reg.GetSecurityQandAs(request);
            Assert.Equal(expectedDictionary, found.Data);
        }
    }
}
