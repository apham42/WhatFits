namespace Whatfits.Models.Interfaces
{
    public interface IWeightLifting
    {
        // Stores the type of Resistance Training
        string LiftingType { get; set; }

        // Stores the Sets of the workout
         int Sets { get; set; }

        // Stores the Repetitions of the workout
         int Reps { get; set; }
    }
}
