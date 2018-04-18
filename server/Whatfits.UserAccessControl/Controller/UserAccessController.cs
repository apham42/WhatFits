using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.UserAccessControl.Service;

namespace Whatfits.UserAccessControl.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccessController
    {
        /*
         * Gives new users a set of default claims.
         * This should only be used in Registration.
         * @returns List<int>, returns list of ints(id of the claims) 
         * */
        public static List<Claim> SetDefaultClaims()
        {
            // create list
            List<Claim> DefaultClaims = new List<Claim>();

            SetDefaultClaims defaultclaims = new SetDefaultClaims();

            // add default claims to new user
            DefaultClaims.AddRange(defaultclaims.GetDefaultClaims());

            // return default claims for new user
            return DefaultClaims;
        }
        
        /// <summary>
        /// Give admin claims
        /// </summary>
        /// <returns>admin claims</returns>
        public static List<Claim> SetAdminClaims()
        {
            List<Claim> AdminClaims = new List<Claim>();

            SetDefaultClaims adminclaims = new SetDefaultClaims();

            AdminClaims.AddRange(adminclaims.GetAdminClaims());

            return AdminClaims;
        }
    }
}