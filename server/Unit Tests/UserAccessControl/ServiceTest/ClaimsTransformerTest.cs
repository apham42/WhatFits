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
        ClaimsTransformer test = new ClaimsTransformer();
        ClaimsPrincipalMockData mockData = new ClaimsPrincipalMockData();
        /// <summary>
        /// if claims principal is null throws SecurityException
        /// </summary>
        [Fact]
        public void IsNull()
        {
            ClaimsPrincipal nullPrincipal = null;

            Action act = () => test.Authenticate(nullPrincipal);

            Assert.Throws<SecurityException>(act);
        }

        /// <summary>
        /// Check if it gets principal gets claims form db correctly
        /// </summary>
        [Fact]
        public void PrincipalHasUsername()
        {
            ClaimsPrincipal principal = mockData.HasUsername();

            // principal that will contain all claims from db
            principal = test.Authenticate(principal);
            
            // list of claims that should be in the principal
            List<Claim> listofClaims = mockData.ClaimsInPrincipal();

            // check if all principal has all the claims in the list
            bool IfPrincipalHasClaim = listofClaims.TrueForAll(claim => principal.HasClaim(claim.Type, claim.Value));


            Assert.True(IfPrincipalHasClaim);
        }

        [Fact]
        public void NoUserName()
        {
            ClaimsPrincipal princpal = new ClaimsPrincipal();

            Action act = () => test.Authenticate(princpal);

            Assert.Throws<NullReferenceException>(act);
        }

    }
}
