using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using Whatfits.UserAccessControl.Service;
using Whatfits.UserAccessControl.Test.Constant;
using Xunit;

namespace Whatfits.UserAccessControl.Test.ServiceTest
{
    public class ClaimsTransformerTest
    {
        /// <summary>
        /// if claims principal is null throws SecurityException
        /// </summary>
        [Fact]
        public void IsNull()
        {
            ClaimsPrincipal nullPrincipal = null;
            ClaimsTransformer test = new ClaimsTransformer();

            Action act = () => test.Authenticate(nullPrincipal);

            Assert.Throws<SecurityException>(act);
        }

        /// <summary>
        /// Check if it gets principal gets claims form db correctly
        /// </summary>
        [Fact]
        public void PrincipalHasUsername()
        {
            ClaimsPrincipal principal = ClaimsPrincipalMockData.HasUsername();

            // principal that will contain all claims from db
            principal = new ClaimsTransformer().Authenticate(principal);
            
            // list of claims that should be in the principal
            List<Claim> listofClaims = ClaimsPrincipalMockData.ClaimsInPrincipal();

            // check if all principal has all the claims in the list
            bool IfPrincipalHasClaim = listofClaims.TrueForAll(claim => principal.HasClaim(claim.Type, claim.Value));


            Assert.True(IfPrincipalHasClaim);
        }

        [Fact]
        public void NoUserName()
        {
            ClaimsPrincipal princpal = new ClaimsPrincipal();

            ClaimsTransformer test = new ClaimsTransformer();

            Action act = () => test.Authenticate(princpal);

            Assert.Throws<NullReferenceException>(act);
        }

    }
}
