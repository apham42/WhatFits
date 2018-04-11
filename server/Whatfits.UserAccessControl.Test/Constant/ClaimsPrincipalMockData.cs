using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.UserAccessControl.Service;

namespace Whatfits.UserAccessControl.Test.Constant
{
    public class ClaimsPrincipalMockData
    {
        public static ClaimsPrincipal NoUserName()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();


            return principal;
        }

        public static ClaimsPrincipal HasUsername()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();

            Claim username = new Claim("UserName", "amay");

            ClaimsIdentity ci = new ClaimsIdentity();
            ci.AddClaim(username);

            principal.AddIdentity(ci);

            return principal;
        }

        public static List<Claim> ClaimsInPrincipal()
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserName", "amay"),
                new Claim("AmayClaimType1", "AmayClaimValue1"),
                new Claim("AmayClaimType1", "AmayClaimValue1"),
                new Claim("WORKOUT_ADD", "Add"),
                new Claim("VIEW_PAGE", "View Wokoutlog"),
                new Claim("WORKOUT_EDIT", "Edit"),
                new Claim("WORKOUT_DELETE", "Delete"),
                new Claim("SEARCH", "True"),
                new Claim("VIEW_PAGE", "View Search"),
                new Claim("CHAT", "True"),
                new Claim("VIEW_PAGE", "View Chat"),
                new Claim("FOLLOW", "True"),
                new Claim("FOLLOWERSLIST", "True"),
                new Claim("VIEW_PAGE", "View Followerslist"),
                new Claim("RATE", "True"),
                new Claim("REVIEW", "True"),
                new Claim("VIEW_PAGE", "View Rating and Reviews"),
                new Claim("EVENT_ADD", "Add"),
                new Claim("EVENT_DELETE", "Delete"),
                new Claim("EVENT_EDIT", "Edit"),
                new Claim("VIEW_PAGE", "View Event")
            };

            

            return claims;
        }

        /// <summary>
        /// get all claims from db
        /// </summary>
        /// <returns>all claims</returns>
        public static List<Claim> GetClaims(string username)
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
