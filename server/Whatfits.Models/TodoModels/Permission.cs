using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whatfits.Models
{
    public partial class Permission
    {
        public Permission()
        {

        }
        [ForeignKey("UserPermission")]
        public int PermissionID { get; set; }
        public UserPermission UserPermission { get; set; }
        public string PermissionGiven { get; set; }
    }
}