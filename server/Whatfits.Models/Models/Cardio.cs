using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Model to represent Cardio Logs
    /// </summary>
    public class Cardio : ICardio
    {
        // Primary Key
        [Key]
        public int CardioID { get; set; }
        // Foreign Key
        [ForeignKey("WorkoutLog")]
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