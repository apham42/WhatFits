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
            var sampleWorkouts = new List<WorkoutLog>
            {
                new WorkoutLog() { WorkoutLogID = 1, UserID = 1, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Cardio"},
                new WorkoutLog() { WorkoutLogID = 2, UserID = 2, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Cardio" },
                new WorkoutLog() { WorkoutLogID = 3, UserID = 3, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Weightlifting" },
                new WorkoutLog() { WorkoutLogID = 4, UserID = 4, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Weightlifting" },
                new WorkoutLog() { WorkoutLogID = 5, UserID = 5, Date_Time = new DateTime(2018, 2, 1), WorkoutType = "Weightlifting" }
            };
            context.Workouts.AddOrUpdate(workouts => workouts.WorkoutLogID, sampleWorkouts.ToArray());
            context.SaveChanges();

            var sampleCardios = new List<Cardio>
            {
                new Cardio() { CardioID = 1, WorkoutID = 1, CardioType = "Sprinting", Distance = 2.54, Time = "6:00" },
                new Cardio() { CardioID = 2, WorkoutID = 2, CardioType = "Running", Distance = 2.54, Time = "3:32" }
            };
            context.Cardios.AddOrUpdate(cardio => cardio.CardioID, sampleCardios.ToArray());
            context.SaveChanges();

            var sampleWeightLifting = new List<WeightLifting>
            {
                new WeightLifting() { WeightLiftingID = 1, WorkoutID = 3, LiftingType = "Curls", Reps = 12, Sets = 4 },
                new WeightLifting() { WeightLiftingID = 2, WorkoutID = 4, LiftingType = "BenchPress", Reps = 12, Sets = 4 },
                new WeightLifting() { WeightLiftingID = 3, WorkoutID = 5, LiftingType = "Curls", Reps = 12, Sets = 4 }
            };
            context.WeightLiftings.AddOrUpdate(WeightLifting => WeightLifting.WeightLiftingID, sampleWeightLifting.ToArray());
            context.SaveChanges();
        }
    }
}
