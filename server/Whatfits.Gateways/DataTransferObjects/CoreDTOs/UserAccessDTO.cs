using System.Collections.Generic;
using System.Security.Claims;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    public class UserAccessDTO
    {
        public int ClaimID { get; set; }
        public string UserName { get; set; }
        public List<Claim> UserClaims {get;set; }
        public List<Claim> ClaimsList { get; set; }
    }
}
