namespace Whatfits.Models.Interfaces
{
    public interface ILocation
    {
        // Stores the Address of the User
        string Address { get; set; }

        // Stores the City of the User
        string City { get; set; }

        // Stores the State of the User
        string State { get; set; }

        // Stores the Zipcode of the User
        string Zipcode { get; set; }

        // Stores the Latitude coordinate
        string Latitude { get; set; }
        
        // Stores the Longitude coordinate
        string Longitude { get; set; }
    }
}
