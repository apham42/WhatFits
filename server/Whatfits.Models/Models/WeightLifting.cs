using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public class WeightLifting
    {
        public WeightLifting()
        {

        }
        // Foreign Key
        public int WorkoutID { get; set; }
        public WorkoutLog WorkoutLog { get; set; }
        // Foreign Key
        public int WeightLiftingID { get; set; }
        public string LiftingType { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
