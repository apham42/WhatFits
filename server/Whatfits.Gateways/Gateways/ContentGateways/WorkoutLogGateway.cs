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
        //database context 
        private WorkoutLogContext db = new WorkoutLogContext();
        //is workout null
        public bool CreateWorkoutLog(WorkoutLogDTO workout)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    int getUserID = (from cred in db.Credentials
                                     where workout.userName == cred.UserName
                                     select cred.UserID).FirstOrDefault();
                    WorkoutLog work = new WorkoutLog
                    {
                        UserID = getUserID,
                        WorkoutType = workout.WorkoutType,
                        Date_Time = workout.Date_Time,
                    };
                    db.Workouts.Add(work);
                    if (workout.WorkoutType.Equals("Cardio"))
                    {
                        Cardio card = new Cardio
                        {
                            CardioType = workout.CardioType,
                            Distance = workout.Distance,
                            Time = workout.Time
                        };
                        db.Cardios.Add(card);
                    }
                    else if (workout.WorkoutType.Equals("WeightLifting"))
                    {
                        WeightLifting weight = new WeightLifting
                        {
                            LiftingType = workout.LiftingType,
                            Reps = workout.Reps,
                            Sets = workout.Sets
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
        //Enumerable returns workotu objects
        public IEnumerable<WorkoutLogDTO> GetWorkouts(UsernameDTO obj)
        {
            int getUserID = (from cred in db.Credentials
                             where obj.Username == cred.UserName
                             select cred.UserID).FirstOrDefault();
            //get workout DTO from cardio table
            var car = (from work in db.Workouts
                       join cred in db.Credentials
                       on work.UserID equals cred.UserID
                       where obj.Username == cred.UserName
                       join card in db.Cardios
                       on work.WorkoutLogID equals card.WorkoutID
                       select new WorkoutLogDTO()
                       {
                           WorkoutType = work.WorkoutType,
                           Date_Time = work.Date_Time,
                           LiftingType = null,
                           Reps = 0,
                           Sets = 0,
                           CardioType = card.CardioType,
                           Distance = card.Distance,
                           Time = card.Time
                       });
            //get workout DTO from weightlifting table
            var weigh = (from work in db.Workouts
                         join cred in db.Credentials
                         on work.UserID equals cred.UserID
                         where obj.Username == cred.UserName
                         join weight in db.WeightLiftings
                         on work.WorkoutLogID equals weight.WorkoutID
                         select new WorkoutLogDTO()
                         {
                             WorkoutType = work.WorkoutType,
                             Date_Time = work.Date_Time,
                             LiftingType = weight.LiftingType,
                             Reps = weight.Reps,
                             Sets = weight.Sets,
                             CardioType = null,
                             Distance = 0,
                             Time = null
                         });
            //union two workoutDTO and returns by date descending
            var logs = (car.Union(weigh).OrderByDescending(m =>m.Date_Time));
            return logs;
        }
    }
}
