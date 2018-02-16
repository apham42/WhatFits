using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class WorkoutLog
    {
        public WorkoutLog()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
        [Key]
        public int WorkoutID { get; set; }
        public string WorkoutType { get; set; }
        public string Date_Time { get; set; }
        public ICollection<WeightLifting> WeightLifting { get; set; }
        public ICollection<Cardio> Cardio { get; set; }

    }
}