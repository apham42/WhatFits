using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Models
{
    public class PersonalKey
    {
        public PersonalKey()
        {

        }
        // Primary Key
        //public int PersonalKeyID { get; set; }
        // Acutal Salt

        public String Salt { get; set; }
        // Foreign Key
        //public int CredentialID { get; set; }
        [Key,ForeignKey("User")]
        public int UserID { get;set;}

        // Nativation Property

        public virtual  User User { get; set; }
    }
}
