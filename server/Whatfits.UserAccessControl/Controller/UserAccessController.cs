using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using Whatfits.UserAccessControl.Constants;

namespace Whatfits.UserAccessControl.Controller
{
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
            List<Claim> DefaultClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Webpage, "Whatfits.social")
            };
            
            // add default claims to new user
            DefaultClaims.AddRange(ClaimConstants.DEFAULT_CLAIMS);

            // return default claims for new user
            return DefaultClaims;

        }
    }
}