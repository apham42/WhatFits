using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.UserAccessControl.Constants;

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
         * @param string username, username of the new registered user
         * @returns List<int>, returns list of ints(id of the claims) 
         * */
        public static List<Claim> SetDefaultClaims(string username)
        {
            // create list
            List<Claim> DefaultClaims = new List<Claim>();

            // add default claims to new user
            DefaultClaims.AddRange(ClaimConstants.DEFAULT_CLAIMS);

            // return default claims for new user
            return DefaultClaims;

        }

        /*
         * Add new claim for user
         * @param Claim claim, new claim to be added
         * */
        public static void AddClaim(Claim claim)
        {

        }

        /*
         * Remove new claim for user
         * @param Claim claim, claim to removed
         * */
        public static void RemoveClaim(Claim claim)
        {

        }
        
        /*
         * Get view page claims from db
         * @return: view page claims 
         * */
        public static List<Claim> GetViewClaims()
        {
            List<Claim> ViewClaims = new List<Claim>();

            return ViewClaims;

        }
    }
}