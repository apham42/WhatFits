using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class UserPermission
    {
        public UserPermission()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Key]
        public int PermissionID { get; set; }
        public int ID;
    }
}