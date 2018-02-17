using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Models
{
    public class Credential
    {
        public Credential()
        {

        }
        [Required][Key]
        public string UserNameID { get; set; }
        public string Password { get; set; }
        // Foreign Key
        public int UserID { get; set; }
        // Navigation Property
        public User User { get; set; }

    }
}
