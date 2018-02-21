using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public class Claim
    {
        public Claim()
        {

        }
        [Key]
        public int ClaimID { get; set; }
        public String ClaimsType { get; set; }
        public String ClaimsValue { get; set; }
        // Foreign Key
        [ForeignKey("Credential")]
        public int UserID { get; set; }
        public virtual Credential Credential { get; set; }
    }
}
