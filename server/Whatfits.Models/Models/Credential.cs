using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public partial class Credential
    {
        public Credential()
        {

        }
        [Key,ForeignKey("User")]
        public int UserID { get; set; }
        // Body
        public string UserName { get; set; }
        public string Password { get; set; }
        // Navigation Property
        public virtual User User { get; set; }
        List<int> ClaimsList { get; set; }
    }
}
