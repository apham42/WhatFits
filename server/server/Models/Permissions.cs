using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Permissions
    {
        public Permissions()
        {

        }
        //public int PermissionID { get; set; }
        // Note: Why do we need PermissionIDs
        public string[] Permission { get; set; }
        // Note: Ask Aaron or Abram on how we are doing the permissions
        [ForeignKey("User")]
        public int UserID { get; set; }
    }
}