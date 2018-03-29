using System;
using System.Security;
using System.Security.Claims;

namespace Whatfits.UserAccessControl.Service
{
    /// <summary>
    /// Get incomming principal and claims from database
    /// </summary>
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        /// <summary>
        /// check if incomming principal is null
        /// </summary>
        /// <param name="incommingPrincipal">users principal</param>
        /// <returns>ClaimsPrinciapl with added claims from db</returns>
        public ClaimsPrincipal Authenticate(ClaimsPrincipal incommingPrincipal)
        {
            // check if token exist
            if (incommingPrincipal == null)
            {
                // throw exception to be caught in AuthenticateHttpMessageHandler
                throw new SecurityException();
            }

            // create principal
            return AddClaimsToPrincipal(incommingPrincipal);
        }
       
        /// <summary>
        /// add claims from db
        /// </summary>
        /// <param name="incommingPrincipal">principal from authenticateHttpMessageHandler</param>
        /// <returns>incommingPrincipal with new claims</returns>
        private ClaimsPrincipal AddClaimsToPrincipal(ClaimsPrincipal incommingPrincipal)
        {
            try
            {
                // new identity for principal
                ClaimsIdentity ci = new ClaimsIdentity();

                // create object to get claims
                UserAccessDatabaseAccess dbAccess = new UserAccessDatabaseAccess(incommingPrincipal.Identity.Name);

                // get claims from db and store in identity
                ci.AddClaims(dbAccess.GetClaims());

                // store new idenityt in principal
                incommingPrincipal.AddIdentity(ci);

                // return principal with all claims
                return incommingPrincipal;
            } catch (Exception)
            {
                // throw Exception to be caught in AuthenticateHttpMessageHandler
                throw new Exception();
            }
        }
    }
}
