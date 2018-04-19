using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class WorkoutLogGateway
    {
        private WorkoutLogContext db = new WorkoutLogContext();
        public bool CreateWorkoutLog(WorkoutLogDTO w)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    int getUserID = (from b in db.Workouts
                                  join cred in db.Credentials
                                  on b.UserID equals cred.UserID
                                  where w.userName == cred.UserName
                                  select cred.UserID).FirstOrDefault();
                    WorkoutLog work = new WorkoutLog
                    {
                        UserID = getUserID,
                        WorkoutType = w.WorkoutType,
                        Date_Time = w.Date_Time,
                    };
                    db.Workouts.Add(work);
                    if (w.WorkoutType.Equals("Cardio"))
                    {
                        Cardio card = new Cardio
                        {
                            CardioType = w.CardioType,
                            Distance = w.Distance,
                            Time = w.Time
                        };
                        db.Cardios.Add(card);
                    }
                    else if(w.WorkoutType.Equals("WeightLifting"))
                    {
                        WeightLifting weight = new WeightLifting
                        {
                            LiftingType = w.LiftingType,
                            Reps = w.Reps,
                            Sets = w.Sets
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
