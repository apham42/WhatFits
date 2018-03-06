using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Whatfits.Models
{
    public class Cardio
    {
        public Cardio()
        {

        }
        // Foreign Key
        public int WorkoutID { get; set; }
        public WorkoutLog WorkoutLog { get; set; }
        // Primary Key
        public int CardioID { get; set; }
        public string CardioType { get; set; }
        public int Distance { get; set; }
        public string Time { get; set; }
    }
}