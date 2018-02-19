using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Whatfits.Models
{
    public class UserPermission
    {
        public UserPermission()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
        [Key]
        public int PermissionID { get; set; }
        public int ID;
        //public ICollection<Permission> Permission{ get; set; }

    }
}