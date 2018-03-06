using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public class Following
    {
        public Following()
        {

        }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }
        // Primary Key
        [Key]
        public int FollowingID { get; set; }

        public int PersonFollowing { get; set; }
    }
}