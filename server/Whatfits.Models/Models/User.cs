using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace server.Models
{
    public class User
    {
        public User()
        {

        }
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        // Users can have many:
        //public ICollection<SecurityAnswer> Answers { get; set; }
        //public ICollection<WorkoutLog> WorkoutLogs { get; set; }
        //public ICollection<UserPermission> UserPermission { get; set; }
        //public ICollection<Event> Event { get; set; }
        //public ICollection<Following> Following { get; set; }
        //public ICollection<Review> Review { get; set; }

    }
}