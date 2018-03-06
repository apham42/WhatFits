using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class WorkoutLog
    {
        public WorkoutLog()
        {

        }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }
        // Primary Key
        public int WorkoutLogID { get; set; }

        public string WorkoutType { get; set; }
        public string Date_Time { get; set; }
        // Workout log can have many Weightlifting Logs and Cardio Logs
        public ICollection<WeightLifting> WeightLifting { get; set; }
        public ICollection<Cardio> Cardio { get; set; }
    }
}