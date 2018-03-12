using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    public class UserAccessDTO
    {
        public int ClaimID { get; set; }
        public string ClaimValue { get; set; }
        public string ClaimType { get; set; }
        public string UserName { get; set; }
        public IEnumerable<int> Claims { get; set; }
    }
}
