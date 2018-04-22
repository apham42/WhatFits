using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class ProfileDTO
    {
        public string ProfilePictureDirectory { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Description { get; set; }
        public string SkillLevel { get; set; }
        public string Gender { get; set; }
    }
}
