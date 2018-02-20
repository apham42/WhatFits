using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public partial class PersonalKey
    {
        public PersonalKey()
        {

        }
        [Key, ForeignKey("Credential")]
        public int UserID { get; set; }
        public virtual Credential Credential{ get; set; }
        public string Salt { get; set; }
    }
}
