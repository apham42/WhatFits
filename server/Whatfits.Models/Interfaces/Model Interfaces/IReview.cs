using System;

namespace Whatfits.Models.Interfaces
{
    public interface IReview
    {
        // Required ID of the other user being reviewed
        int RevieweeID { get; set; }

        // Records rating with a 1-5 rating      
        int Rating { get; set; }

        // Records the message of the review of the other user
        string ReviewMessage { get; set; }

        // Records the DateTime when the review was created
        DateTime DateAndTime { get; set; }
    }
}
