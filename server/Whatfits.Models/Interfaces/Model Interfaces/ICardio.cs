namespace Whatfits.Models.Interfaces
{
    public interface ICardio
    {   
        // Stores the type of cardio done
        string CardioType { get; set; }
        
        // Stores the distance ran
        double Distance { get; set; }
        
        // Stores the time ran
        string Time { get; set; }
    }
}
