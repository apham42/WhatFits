namespace Whatfits.Models.Migrations.CoreMigrations.RegistrationMigrations
{
    using Whatfits.Models.Models;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Core.RegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CoreMigrations\RegistrationMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Core.RegistrationContext context)
        {
            // NOTE: Only use to create tables for CORE features and any other content.
            /*
             var credentials = new List<Credential>
             {
                 new Credential{ UserName = "latmey", Password = "123456", IsBanned = true, IsFullyRegistered = true },
                 new Credential{ UserName = "amay", Password = "123456", IsBanned = true, IsFullyRegistered = true },
                 new Credential{ UserName = "rstrong", Password = "123456", IsBanned = true, IsFullyRegistered = true },
                 new Credential{ UserName = "rblue", Password = "123456", IsBanned = true, IsFullyRegistered = true },
                 new Credential{ UserName = "chackins", Password = "123456", IsBanned = true, IsFullyRegistered = true }
             };
             credentials.ForEach(c => context.Credentials.Add(c));
             context.SaveChanges();

             var users = new List<User>
             {
                 new User{ UserID = 0001, FirstName = "Luke",  LastName = "Atmey", Email = "asdf@gmail.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Beginner"},
                 new User{ UserID = 0002, FirstName = "April", LastName = "May", Email = "asdf@facebook.com", Description = "SomeDescription", Gender = "Female", ProfilePicture = null, SkillLevel = "Beginner"},
                 new User{ UserID = 0003, FirstName = "Rock", LastName = "Strong", Email = "asdf@live.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "FuckingNoob" },
                 new User{ UserID = 0004, FirstName = "Red", LastName = "Blue", Email = "asdf@yahoo.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced"},
                 new User{ UserID = 0005, FirstName = "Cody", LastName = "Hackins", Email = "zzz@channel.com", Description = "SomeDescription", Gender = "Male", ProfilePicture = null, SkillLevel = "Advanced"},
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

             var claims = new List<ClaimItem>
             {
                 new ClaimItem{ ClaimType = "User", ClaimValue = "Add"},
                 new ClaimItem{ ClaimType = "User", ClaimValue = "Edit"},
                 new ClaimItem{ ClaimType = "User", ClaimValue = "Disable"},
                 new ClaimItem{ ClaimType = "User", ClaimValue = "Delete"},
                 new ClaimItem{ ClaimType = "Event", ClaimValue = "Create"},
                 new ClaimItem{ ClaimType = "Event", ClaimValue = "Edit"},
                 new ClaimItem{ ClaimType = "Event", ClaimValue = "Delete"},
                 new ClaimItem{ ClaimType = "Review", ClaimValue = "True"},
                 new ClaimItem{ ClaimType = "Rate", ClaimValue = "True"},
                 new ClaimItem{ ClaimType = "Follow", ClaimValue = "Following"},
                 new ClaimItem{ ClaimType = "Follow", ClaimValue = "Following"},
                 new ClaimItem{ ClaimType = "Chat", ClaimValue = "True"},
                 new ClaimItem{ ClaimType = "Search", ClaimValue = "True"},
                 new ClaimItem{ ClaimType = "Workoutlog", ClaimValue = "Add"},
                 new ClaimItem{ ClaimType = "Workoutlog", ClaimValue = "View" }
             };
             claims.ForEach(c => context.Claims.Add(c));
             context.SaveChanges();
             var userClaims = new List<UserClaims>
             {
                 new UserClaims{ UserID = 0001, ClaimID = 1},
                 new UserClaims{ UserID = 0001, ClaimID = 2},
                 new UserClaims{ UserID = 0002, ClaimID = 1},
                 new UserClaims{ UserID = 0002, ClaimID = 2},
                 new UserClaims{ UserID = 0003, ClaimID = 1},
                 new UserClaims{ UserID = 0003, ClaimID = 2},
                 new UserClaims{ UserID = 0004, ClaimID = 1},
                 new UserClaims{ UserID = 0004, ClaimID = 2},
                 new UserClaims{ UserID = 0005, ClaimID = 1},
                 new UserClaims{ UserID = 0005, ClaimID = 2}
             };
             userClaims.ForEach(uc => context.UserClaims.Add(uc));
             context.SaveChanges();

             var locations = new List<Location>
             {
                 new Location{ UserID = 0001, Address = "1865 Locust Court", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = "Null", Longitude="Null"},
                 new Location{ UserID = 0002, Address = "4358 Maple Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = "Null", Longitude="Null"},
                 new Location{ UserID = 0003, Address = "2962 Sharon Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = "Null", Longitude="Null"},
                 new Location{ UserID = 0004, Address = "3782 Jennifer Lane", City = "Long Beach", State = "California", Zipcode = "90840" , Latitude = "Null", Longitude="Null"},
                 new Location{ UserID = 0005, Address = "7059 Roehampton Ave. ", City = "Long Beach", State = "California", Zipcode = "90840", Latitude = "Null", Longitude="Null"}
             };
             locations.ForEach(l => context.Locations.Add(l));
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

             var answers = new List<SecurityQandA>
             {
                 new SecurityQandA{ UserID = 0001, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityQandA{ UserID = 0001, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityQandA{ UserID = 0001, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityQandA{ UserID = 0002, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityQandA{ UserID = 0002, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityQandA{ UserID = 0002, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityQandA{ UserID = 0003, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityQandA{ UserID = 0003, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityQandA{ UserID = 0003, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityQandA{ UserID = 0004, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityQandA{ UserID = 0004, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityQandA{ UserID = 0004, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
                 new SecurityQandA{ UserID = 0005, SecurityQuestionID = 1, Answer = "Answer to Question 1"},
                 new SecurityQandA{ UserID = 0005, SecurityQuestionID = 3, Answer = "Answer to Question 3"},
                 new SecurityQandA{ UserID = 0005, SecurityQuestionID = 4, Answer = "Answer to Question 4"},
             };
             answers.ForEach(a => context.SecurityQandA.Add(a));
             context.SaveChanges();
             //*/
        }
    }
}
