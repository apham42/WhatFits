
namespace Whatfits.Models.Models
{
    public class WeightLifting
    {
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
