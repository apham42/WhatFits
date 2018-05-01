using server.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Services
{
    public class WorkoutLoggerService
    {

        public bool Create(WorkoutLogDTO w)
        {
            //IF NOT EQUAL CARDIO AND WEIGHTLIFTING return false
            if (!(w.WorkoutType.Equals("Cardio")) && !(w.WorkoutType.Equals("WeightLifting")))
            {
                return false;
            }
            //check if inputs are 1, if string it will return false
            //Cardio types have an initialized 0 for reps/sets
            if (!(w.Reps % 1 == 0))
            {
                return false;
            }
            if (!(w.Sets % 1 == 0))
            {
                return false;
            }
            //need regex
            //Regex testReg = new Regex("^[0-9]+$");
            //// Testing first name and last name
            //if (!testReg.IsMatch(obj.FirstName) || !testReg.IsMatch(obj.LastName))
            //{
            //    return false;
            //}
            var gateway = new WorkoutLogGateway();
            return gateway.CreateWorkoutLog(w);
        }

        //Returns Review objects to front end, ReviewMessage, Rating, and Datetime
        public IEnumerable<WorkoutLogDTO> GetUserWorkouts(UsernameDTO obj)
        {
            var gateway = new WorkoutLogGateway();
            return gateway.GetWorkouts(obj);
        }
    }
}