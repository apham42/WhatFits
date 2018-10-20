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
        }
    }
}
