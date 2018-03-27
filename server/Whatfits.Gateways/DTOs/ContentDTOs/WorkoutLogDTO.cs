using System;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class WorkoutLogDTO : IWorkoutLog, ICardio, IWeightLifting
    {
        public string WorkoutType { get; set; }
        public DateTime Date_Time { get; set; }

        public string CardioType { get; set; }
        public double Distance { get; set; }
        public string Time { get; set; }

        public string LiftingType { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
