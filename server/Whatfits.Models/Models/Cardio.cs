using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Model to represent Cardio Logs
    /// </summary>
    public class Cardio
    {
        // Primary Key
        [Key, Column(Order = 0)]
        public int CardioID { get; set; }
        // Foreign Key
        [Key, Column(Order = 1)]
        public int WorkoutID { get; set; }
        // Stores the type of cardio done
        [Required]
        public string CardioType { get; set; }
        // Stores the distance ran
        [Required]
        public double Distance { get; set; }
        // Stores the time ran
        [Required]
        public string Time { get; set; }

        // Navigation Property for Workoutlog
        public virtual WorkoutLog WorkoutLog { get; set; }
    }
}