namespace Whatfits.Models.Migrations.ContentMigrations.WorkoutLogMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Whatfits.Models.Context.Content.WorkoutLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContentMigrations\WorkoutLogMigrations";
        }

        protected override void Seed(Whatfits.Models.Context.Content.WorkoutLogContext context)
        {
            /*
            var workouts = new List<WorkoutLog>
            {
                   new WorkoutLog() { UserID = 1, Date_Time = new DateTime(2018, 2, 1), WorkoutType= "Cardio"},
                   new WorkoutLog() { UserID = 2, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Cardio" },
                   new WorkoutLog() { UserID = 3, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Weightlifting" },
                   new WorkoutLog() { UserID = 4, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Cardio" },
                   new WorkoutLog() { UserID = 5, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Cardio" }
            };
            workouts.ForEach(c => context.Workouts.Add(c));
            context.SaveChanges();
            //*/
            /*
            context.Cardios.AddOrUpdate(x => x.CardioID,
                  new Cardio() { WorkoutID = 1, CardioType = "Sprinting", Distance = 2.54, Time = "6:00" },
                  new Cardio() { WorkoutID = 2, CardioType = "Running", Distance = 2.54, Time = "3:32" }
               );
            context.WeightLiftings.AddOrUpdate(x => x.WeightLiftingID,
                  new WeightLifting() { WorkoutID = 3, LiftingType = "Curls", Reps = 12, Sets = 4 },
                  new WeightLifting() { WorkoutID = 4, LiftingType = "BenchPress", Reps = 12, Sets = 4 },
                  new WeightLifting() { WorkoutID = 5, LiftingType = "Curls", Reps = 12, Sets = 4 }
               );
            //*/
        }
    }
}
