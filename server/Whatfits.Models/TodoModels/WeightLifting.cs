using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class WeightLifting
    {
        public WeightLifting()
        {

        }
        [ForeignKey("WorkoutLog")]
        public int WorkoutID { get; set; }
        public WorkoutLog WorkoutLog { get; set; }
        [Key]
        public int WeightLiftingID { get; set; }
        public string LiftingType { get; set; }
        public int sets { get; set; }
        public int reps { get; set; }
    }
}