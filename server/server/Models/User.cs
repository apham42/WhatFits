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
        public string Gender { get; set; }
        public string Address { get; set; }
        // The Following line is being debated by team
        // public User[] Followers { get; set; }
        //public ICollection<User> Followers { get; set; }
    }
}