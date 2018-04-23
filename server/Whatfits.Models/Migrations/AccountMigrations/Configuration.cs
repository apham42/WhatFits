namespace Whatfits.Models.Migrations.AccountMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Core.AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AccountMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Core.AccountContext context)
        {
            
            var sampleCredentials = new List<Credential>
           {
               new Credential{ UserName = "latmey", Password = "123456" },
               new Credential{ UserName = "amay", Password = "123456" },
               new Credential{ UserName = "rstrong", Password = "123456" },
               new Credential{ UserName = "rblue", Password = "123456" },
               new Credential{ UserName = "chackins", Password = "123456" },
               new Credential{ UserName = "TestUser1", Password = "123456" },
               new Credential{ UserName = "TestUser2", Password = "123456" },
           };
            context.Credentials.AddOrUpdate(credentials => credentials.UserName, (sampleCredentials.ToArray()));
            context.SaveChanges();

            var sampleLocations = new List<Location>
               {
                   new Location{ LocationID = 1, Address = "1865 Locust Court", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = 0, Longitude= 0},
                   new Location{ LocationID = 2, Address = "4358 Maple Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = 0, Longitude= 0},
                   new Location{ LocationID = 3, Address = "2962 Sharon Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = 0, Longitude= 0},
                   new Location{ LocationID = 4, Address = "3782 Jennifer Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = 0, Longitude= 0},
                   new Location{ LocationID = 5, Address = "7059 Roehampton Ave. ", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = 0, Longitude= 0},
                   new Location{ LocationID = 6, Address = "7059 Roehampton Ave. ", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = 0, Longitude= 0},
                   new Location{ LocationID = 7, Address = "7059 Roehampton Ave. ", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = 0, Longitude= 0}
               };
            context.Locations.AddOrUpdate(locations => locations.LocationID, (sampleLocations.ToArray()));
            context.SaveChanges();

            var sampleProfiles = new List<UserProfile>
             {
                 new UserProfile{ UserID = 0001, LocationID = 1, FirstName = "Luke",  LastName = "Atmey", Email = "asdf@gmail.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Beginner" , Type = "Enable"},
                 new UserProfile{ UserID = 0002, LocationID = 1, FirstName = "April", LastName = "May", Email = "asdf@facebook.com", Description = "SomeDescription", Gender = "Female", ProfilePicture = null, SkillLevel = "Beginner", Type = "Enable"},
                 new UserProfile{ UserID = 0003, LocationID = 3, FirstName = "Rock", LastName = "Strong", Email = "asdf@live.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Beginner" , Type = "Enable"},
                 new UserProfile{ UserID = 0004, LocationID = 4, FirstName = "Red", LastName = "Blue", Email = "asdf@yahoo.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced", Type = "Enable"},
                 new UserProfile{ UserID = 0005, LocationID = 5, FirstName = "Cody", LastName = "Hackins", Email = "zzz@channel.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced", Type = "Enable"},
                 new UserProfile{ UserID = 0006, LocationID = 5, FirstName = "Test", LastName = "User", Email = "zzz@channel.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced", Type = "Enable"},
                 new UserProfile{ UserID = 0007, LocationID = 5, FirstName = "Test", LastName = "User", Email = "zzz@channel.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced", Type = "Enable"}
             };
            context.UserProfiles.AddOrUpdate(users => users.UserID, (sampleProfiles.ToArray()));
            context.SaveChanges();

            var sampleSalts = new List<Salt>
             {
                 new Salt{ UserID = 0001, SaltValue = "asdf"},
                 new Salt{ UserID = 0002, SaltValue = "fdsaf"},
                 new Salt{ UserID = 0003, SaltValue = "asdewaf"},
                 new Salt{ UserID = 0004, SaltValue = "ase2df"},
                 new Salt{ UserID = 0005, SaltValue = "as32eddf"},
                 new Salt{ UserID = 0006, SaltValue = "dfadfadfa"},
                 new Salt{ UserID = 0007, SaltValue = "adsfasdfad"},
             };
            context.Salts.AddOrUpdate(salts => salts.UserID, (sampleSalts.ToArray()));
            context.SaveChanges();

            var sampleClaims = new List<UserClaims>
             {
                 new UserClaims{ ClaimID = 1, UserID = 0001, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ ClaimID = 2, UserID = 0001, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ ClaimID = 3, UserID = 0002, ClaimType="AmayClaimType1", ClaimValue="AmayClaimValue1"},
                 new UserClaims{ ClaimID = 4, UserID = 0002, ClaimType="AmayClaimType2", ClaimValue="AmayClaimValue2"},
                 new UserClaims{ ClaimID = 5, UserID = 0003, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ ClaimID = 6, UserID = 0003, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ ClaimID = 7, UserID = 0004, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ ClaimID = 8, UserID = 0004, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ ClaimID = 9, UserID = 0005, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ ClaimID = 10,UserID = 0005, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ ClaimID = 11,UserID = 0006, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ ClaimID = 12,UserID = 0007, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
             };
            context.UserClaims.AddOrUpdate(userclaims => userclaims.ClaimID, (sampleClaims.ToArray()));
            context.SaveChanges();
            
            var sampleQuestions = new List<SecurityQuestion>
             {
                 new SecurityQuestion{ Question = "Who was the company you first worked for?"},
                 new SecurityQuestion{ Question = "Where did you go to highschool or college?"},
                 new SecurityQuestion{ Question = "What was the name of the teacher who gave you your first failing grade?"},
                 new SecurityQuestion{ Question = "What is your favorite song?"},
                 new SecurityQuestion{ Question = "What is your mother's maiden name?"},
                 new SecurityQuestion{ Question = "What is your favorite sports team?"},
                 new SecurityQuestion{ Question = "What was the name of your first crush?"},
                 new SecurityQuestion{ Question = "What is the first name of the person you first kissed?"},
                 new SecurityQuestion{ Question = "In what city or town does your nearest sibling live?"}
             };
            context.SecurityQuestions.AddOrUpdate(securityQuestions => securityQuestions.Question, (sampleQuestions.ToArray()));
            context.SaveChanges();
           
            var sampleAnswers = new List<SecurityAccount>
             {
                 new SecurityAccount{ SecurityAccountID = 1, UserID = 0001, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 2, UserID = 0001, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 3, UserID = 0001, SecurityQuestionID = 4, Answer = "Answer to Question 4" },
                 new SecurityAccount{ SecurityAccountID = 4, UserID = 0002, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 5, UserID = 0002, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 6, UserID = 0002, SecurityQuestionID = 4, Answer = "Answer to Question 4" },
                 new SecurityAccount{ SecurityAccountID = 7, UserID = 0003, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 8, UserID = 0003, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 9, UserID = 0003, SecurityQuestionID = 4, Answer = "Answer to Question 4" },
                 new SecurityAccount{ SecurityAccountID = 10, UserID = 0004, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 11, UserID = 0004, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 12, UserID = 0004, SecurityQuestionID = 4, Answer = "Answer to Question 4" },
                 new SecurityAccount{ SecurityAccountID = 13, UserID = 0005, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 14, UserID = 0005, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 15, UserID = 0005, SecurityQuestionID = 4, Answer = "Answer to Question 4" },
                 new SecurityAccount{ SecurityAccountID = 16, UserID = 0006, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 17, UserID = 0006, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 18, UserID = 0006, SecurityQuestionID = 4, Answer = "Answer to Question 4" },
                 new SecurityAccount{ SecurityAccountID = 19, UserID = 0007, SecurityQuestionID = 1, Answer = "Answer to Question 1" },
                 new SecurityAccount{ SecurityAccountID = 20, UserID = 0007, SecurityQuestionID = 3, Answer = "Answer to Question 3" },
                 new SecurityAccount{ SecurityAccountID = 21, UserID = 0007, SecurityQuestionID = 4, Answer = "Answer to Question 4" }
             };
            context.SecurityAccounts.AddOrUpdate(securityAccount => securityAccount.SecurityAccountID, (sampleAnswers.ToArray()));
            context.SaveChanges();

            var sampleBlackList = new List<TokenBlackList>
           {
               new TokenBlackList { TokenBlackListID = 1, UserID = 1, Token = "adhlfkjh323hdh93"},

           };
            context.TokenBlackLists.AddOrUpdate(tokenblacklist => tokenblacklist.UserID, (sampleBlackList.ToArray()));
            context.SaveChanges();
            
        }
    }
}
