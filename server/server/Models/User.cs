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
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public ICollection<SecurityAnswer> Answers { get; set; }
        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
        //public ICollection<Following> Followings { get; set; }
        public ICollection<Event> Event { get; set; }
        public ICollection<Following> Following { get; set; }

    }
}