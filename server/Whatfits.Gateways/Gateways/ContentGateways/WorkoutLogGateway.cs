using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
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
                    int getUserID = (from cred in db.Credentials
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
                    else if (w.WorkoutType.Equals("WeightLifting"))
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
        //need to fix cardio splitters
        public IEnumerable<WorkoutLogDTO> GetWorkouts(UsernameDTO obj)
        {
            int getUserID = (from cred in db.Credentials
                             where obj.Username == cred.UserName
                             select cred.UserID).FirstOrDefault();
                
                var car = (from b in db.Workouts
                        join cred in db.Credentials
                        on b.UserID equals cred.UserID
                        where obj.Username == cred.UserName
                        join card in db.Cardios
                        on b.WorkoutLogID equals card.WorkoutID
                        select new WorkoutLogDTO()
                        {
                            WorkoutType = b.WorkoutType,
                            Date_Time = b.Date_Time,
                            LiftingType = null,
                            Reps = 0,
                            Sets = 0,
                            CardioType = card.CardioType,
                            Distance = card.Distance,
                            Time = card.Time
                        });
            var weigh = (from b in db.Workouts
                                  join cred in db.Credentials
                                  on b.UserID equals cred.UserID
                                  where obj.Username == cred.UserName
                                  join weight in db.WeightLiftings
                                  on b.WorkoutLogID equals weight.WorkoutID
                                  select new WorkoutLogDTO()
                                  {
                                      WorkoutType = b.WorkoutType,
                                      Date_Time = b.Date_Time,
                                      LiftingType = weight.LiftingType,
                                      Reps = weight.Reps,
                                      Sets = weight.Sets,
                                      CardioType = null,
                                      Distance = 0,
                                      Time = null
                                  });
            var logs = (car.Union(weigh).OrderBy(m =>m.Date_Time));
            return logs;
        }
    }
}
