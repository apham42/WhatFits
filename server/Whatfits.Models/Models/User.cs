using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Whatfits.Models
{
    public partial class User
    {
        public User()
        {

        }
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        // User can have One:
        public  virtual Credential Credential { get; set; }
        // Users can have many:
        public ICollection<Message> Messages { get; set; }
        public ICollection<Event> Event { get; set; }
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
        public ICollection<Following> Following { get; set; }
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}