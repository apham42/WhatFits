using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Following
    {
        public Following()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
        [Key]
        public int FollowingID { get; set; }
        public string FollowingEmail { get; set; }
    }
}