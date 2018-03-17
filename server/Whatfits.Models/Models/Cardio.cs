namespace Whatfits.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Cardio
    {
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