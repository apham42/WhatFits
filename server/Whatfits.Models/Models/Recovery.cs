using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models.Models
{
    public class Recovery
    {
        public Recovery()
        {

        }
        // Primary Key
        [Key, ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
