using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.CoreDTOs
{
    public class UserAccessDTO
    {
        // User being used
        public string UserName { get; set; }
        // To set or get UserClaims
        public List<Claim> UserClaims {get;set; }
    }
}
