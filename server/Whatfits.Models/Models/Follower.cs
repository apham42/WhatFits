using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public class Follower
    {
        public Follower()
        {

        }
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }
        // Primary Key
        public int FollowerID { get; set; }

        public int FollowingPerson { get; set; }

    }
}
