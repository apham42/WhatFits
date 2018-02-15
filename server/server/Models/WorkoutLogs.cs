using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class WorkoutLogs
    {
        public WorkoutLogs()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key]
        public int WorkoutID { get; set; }
        public string WorkoutType { get; set; }
        public string Date_Time { get; set; }
        // Note: Better to use Time object?
    }
}