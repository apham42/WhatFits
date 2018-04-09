namespace Whatfits.Models.Interfaces
{
    public interface IUserProfile
    {
        string Email { get; set; }
        string ProfilePicture { get; set; }
        string FirstName { get; set; } 
        string LastName { get; set; }      
        string Gender { get; set; }
        string SkillLevel { get; set; }
        string Description { get; set; }
        string Type { get; set; }
    }
}
