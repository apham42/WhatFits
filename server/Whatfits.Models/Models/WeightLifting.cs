using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Models to represent Weightlifting Logs
    /// </summary>
    public class WeightLifting : IWeightLifting
    {
        // Primary Key
        [Key, Column(Order = 0)]
        public int WeightLiftingID { get; set; }

        // Foreign Key to the workoutLog
        [Key, Column(Order = 1)]
        public int WorkoutID { get; set; }

        // Stores the type of Resistance Training
        [Required]
        public string LiftingType { get; set; }

        // Stores the Sets of the workout
        [Required]
        public int Sets { get; set; }

        // Stores the Repetitions of the workout
        [Required]
        public int Reps { get; set; }

        // Navigation Property for Workoutlog
        public virtual WorkoutLog WorkoutLog { get; set; }
    }
}
