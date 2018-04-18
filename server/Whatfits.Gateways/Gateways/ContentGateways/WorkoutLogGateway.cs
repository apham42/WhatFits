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
                    WorkoutLog temp = new WorkoutLog
                    {
                        WorkoutType = w.WorkoutType,
                        Date_Time = w.Date_Time, 
                        WeightLifting = w.collection
                    };
                    //add into database t he new instance and saves
                    db.Review.Add(r);
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
