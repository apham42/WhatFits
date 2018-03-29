using System;

namespace Whatfits.Models.Interfaces
{
    public interface IWorkoutLog
    { 
        // Stores the workoutype
        string WorkoutType { get; set; }

        // Stores the date and time it was created
        DateTime Date_Time { get; set; }
    }
}
