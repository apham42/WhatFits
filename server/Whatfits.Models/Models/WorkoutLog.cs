using System.Collections.Generic;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkoutLog
    {
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