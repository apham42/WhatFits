using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Models
{
    public class UserClaims
    {
        public UserClaims()
        {

        }
        [Key]
        public int UserClaimsID { get; set; }
        public int ClaimID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
