using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Whatfits.DataAccess.DTOs
{
    public class UserSearch
    {
        public string User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SkillLevel { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
