namespace Whatfits.Models.Migrations.AccountMigrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
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
           //*
           var credentials = new List<Credential>
           {
               new Credential{ UserName = "latmey", Password = "123456" },
               new Credential{ UserName = "amay", Password = "123456" },
               new Credential{ UserName = "rstrong", Password = "123456" },
               new Credential{ UserName = "rblue", Password = "123456" },
               new Credential{ UserName = "chackins", Password = "123456" }
           };
           credentials.ForEach(c => context.Credentials.Add(c));
           context.SaveChanges();

           var locations = new List<Location>
               {
                   new Location{ Address = "1865 Locust Court", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = "Null", Longitude="Null"},
                   new Location{ Address = "4358 Maple Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = "Null", Longitude="Null"},
                   new Location{ Address = "2962 Sharon Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = "Null", Longitude="Null"},
                   new Location{ Address = "3782 Jennifer Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = "Null", Longitude="Null"},
                   new Location{ Address = "7059 Roehampton Ave. ", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = "Null", Longitude="Null"}
               };
           locations.ForEach(l => context.Locations.Add(l));
           context.SaveChanges();

           var users = new List<UserProfile>
             {
                 new UserProfile{ UserID = 0001, LocationID = 1, FirstName = "Luke",  LastName = "Atmey", Email = "asdf@gmail.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Beginner" , Type = "General"},
                 new UserProfile{ UserID = 0002, LocationID = 1, FirstName = "April", LastName = "May", Email = "asdf@facebook.com", Description = "SomeDescription", Gender = "Female", ProfilePicture = null, SkillLevel = "Beginner", Type = "General"},
                 new UserProfile{ UserID = 0003, LocationID = 3, FirstName = "Rock", LastName = "Strong", Email = "asdf@live.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "FuckingNoob" , Type = "General"},
                 new UserProfile{ UserID = 0004, LocationID = 4, FirstName = "Red", LastName = "Blue", Email = "asdf@yahoo.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced", Type = "General"},
                 new UserProfile{ UserID = 0005, LocationID = 5, FirstName = "Cody", LastName = "Hackins", Email = "zzz@channel.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced", Type = "General"},
             };
           users.ForEach(u => context.Users.Add(u));
           context.SaveChanges();

           var salts = new List<Salt>
             {
                 new Salt{ UserID = 0001, SaltValue = "asdf"},
                 new Salt{ UserID = 0002, SaltValue = "asdf"},
                 new Salt{ UserID = 0003, SaltValue = "asdf"},
                 new Salt{ UserID = 0004, SaltValue = "asdf"},
                 new Salt{ UserID = 0005, SaltValue = "asdf"}
             };
           salts.ForEach(s => context.Salts.Add(s));
           context.SaveChanges();

           var userClaims = new List<UserClaims>
             {
                 new UserClaims{ UserID = 0001, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ UserID = 0001, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ UserID = 0002, ClaimType="AmayClaimType1", ClaimValue="AmayClaimValue1"},
                 new UserClaims{ UserID = 0002, ClaimType="AmayClaimType2", ClaimValue="AmayClaimValue2"},
                 new UserClaims{ UserID = 0003, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ UserID = 0003, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ UserID = 0004, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ UserID = 0004, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
                 new UserClaims{ UserID = 0005, ClaimType="ClaimType", ClaimValue="ClaimValue3"},
                 new UserClaims{ UserID = 0005, ClaimType="ClaimType", ClaimValue="ClaimValue1"},
             };
           userClaims.ForEach(uc => context.UserClaims.Add(uc));
           context.SaveChanges();
           var questions = new List<SecurityQuestion>
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
           questions.ForEach(q => context.SecurityQuestions.Add(q));
           context.SaveChanges();
           var answers = new List<SecurityAccount>
             {
                 new SecurityAccount{ UserID = 0001, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityAccount{ UserID = 0001, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityAccount{ UserID = 0001, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityAccount{ UserID = 0002, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityAccount{ UserID = 0002, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityAccount{ UserID = 0002, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityAccount{ UserID = 0003, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityAccount{ UserID = 0003, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityAccount{ UserID = 0003, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityAccount{ UserID = 0004, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityAccount{ UserID = 0004, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityAccount{ UserID = 0004, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityAccount{ UserID = 0005, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityAccount{ UserID = 0005, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityAccount{ UserID = 0005, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
             };
           answers.ForEach(a => context.SecurityQandA.Add(a));
           context.SaveChanges();
           var tokenBlackList = new List<TokenBlackList>
           {
               new TokenBlackList { Tokens = "adhlfkjh323hdh93"},
               new TokenBlackList { Tokens = "7sfgsfg8s7fgsdff"},
               new TokenBlackList { Tokens = "bsdf23kjhl23lkjk"},
               new TokenBlackList { Tokens = "fhh4j3l4h4f943hf"},
               new TokenBlackList { Tokens = "89f3b4uqi345tu5h"}
           };
           tokenBlackList.ForEach(c => context.TokenBlackLists.Add(c));
           context.SaveChanges();
           //*/
        }
    }
}
