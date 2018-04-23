using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ProfileDTO
    {
        public ProfileDTO()
        {
            FirstName = null;
            LastName = null;
            Description = null;
            SkillLevel = null;
            Gender = null;
            Email = null;
            ProfilePicture = null;
            UserName = null;
        }
        public ProfileDTO(string firstName, string lastName, string description, string skillLevel,string email, string gender, string profilePicture)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            SkillLevel = skillLevel;
            Email = email;
            Gender = gender;
            ProfilePicture = profilePicture;
        }
        public ProfileDTO(string firstName, string lastName, string description, string skillLevel, string email, string gender, string profilePicture, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            SkillLevel = skillLevel;
            Email = email;
            Gender = gender;
            ProfilePicture = profilePicture;
            UserName = userName;
        }
        public string ProfilePicture { get; set; }
        public string UserName { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string SkillLevel { get; set; }
        public string Gender { get; set; }
    }
}
