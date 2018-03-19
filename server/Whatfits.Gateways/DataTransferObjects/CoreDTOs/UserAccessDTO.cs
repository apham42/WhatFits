using System.Collections.Generic;
using System.Security.Claims;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    public class UserAccessDTO
    {
        // ClaimID to be stored for users
        public List<int> ClaimID { get; set; }
        // Claim to be added to ClaimsList
        public Claim ClaimItem { get; set; }
        // User being used
        public string UserName { get; set; }
        // To Return UserClaims of a User
        public List<Claim> UserClaims {get;set; }
        // To Return ClaimsList
        public List<Claim> ClaimsList { get; set; }
    }
}
