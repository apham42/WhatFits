using System;

namespace Whatfits.Models.Interfaces
{
    public interface IEvent
    {
        // Title for the event
        string Title { get; set; }

        // Time stamp when the event was created
        string CreatedAt { get; set; }

        // Time when the event will take place
        DateTime DateAndTime { get; set; }

        // A general description of the event
        string Description { get; set; }

        // OPTIONAL: An image for the event
        string Image { get; set; }
    }
}
