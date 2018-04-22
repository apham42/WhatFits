using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;
using Xunit;

namespace Unit_Tests.Workout_Test
{
    public class CreateWorkoutTest
    {
        WorkoutLogGateway test = new WorkoutLogGateway();
        private WorkoutLogContext db = new WorkoutLogContext();
        [Fact]
        public bool CreateWorkout()
        { 
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    WorkoutLog w = new WorkoutLog
                    {
                        UserID = 1,
                        WorkoutType = "Cardio",
                        Date_Time = new DateTime(2015, 12, 12)
                    };
                    db.Workouts.Add(w);
                    if (w.WorkoutType.Equals("Cardio"))
                    {
                        Cardio card = new Cardio
                        {
                            CardioType = "Sprinting",
                            Distance = 12.21,
                            Time = "12:32"
                        };
                        db.Cardios.Add(card);
                    }
                    else if (w.WorkoutType.Equals("WeightLifting"))
                    {
                        WeightLifting weight = new WeightLifting
                        {
                            LiftingType = "",
                            Reps = 0,
                            Sets = 0
                        };
                        db.WeightLiftings.Add(weight);
                    }
                    //add into database t he new instance and saves
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
                catch (DataException)
                {
                    dbTransaction.Rollback();
                    return false;
                }
            }
        }
    }
}
