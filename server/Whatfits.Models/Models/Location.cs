using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public class Location
    {
        public Location()
        {

        }
        // Primary Key
        public int LocationID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set;}
        // Location can have many users
        ICollection<User> Users { get; set; }
    }
}
