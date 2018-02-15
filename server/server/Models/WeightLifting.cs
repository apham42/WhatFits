using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class WeightLifting
    {
        public WeightLifting()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key]
        public int WorkoutID { get; set; }
        public string LiftingType { get; set; }
        public int sets { get; set; }
        public int reps { get; set; }
        // NOTE: Should we have a separate table for reps and sets
    }
}