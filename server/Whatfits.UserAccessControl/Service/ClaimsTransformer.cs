using System.Collections.Generic;
using System.Security;
using System.Security.Claims;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

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
        /// <exception>All exceptions will be caught in AuthenticateHttpMessageHandler</exception>"
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
        /// <exception>All exceptions will be caught in AuthenticateHttpMessageHandler</exception>"
        private ClaimsPrincipal AddClaimsToPrincipal(ClaimsPrincipal incommingPrincipal)
        {
                string username = incommingPrincipal.FindFirst(claim => claim.Type == "UserName").Value;

                // new identity for principal
                ClaimsIdentity ci = new ClaimsIdentity();

                // get all claims
                List<Claim> allClaims = GetClaims(username);

                // Add Claims to identity
                ci.AddClaims(allClaims);

                // store new identity in principal
                incommingPrincipal.AddIdentity(ci);

                // return principal with all claims
                return incommingPrincipal;
        }

        /// <summary>
        /// get all claims from db
        /// </summary>
        /// <returns>all claims</returns>
        private List<Claim> GetClaims(string username)
        {
            // user access dto that stores username, will be passed into gateway
            UserAccessDTO userAccessDTO = new UserAccessDTO()
            {
                UserName = username
            };

            // gets all user's claims
            List<Claim> allClaims = new UserAccessControlGateway().GetUserClaims(userAccessDTO).Data;
            
            // returns just view page claims
            return allClaims;
        }
    }
}
