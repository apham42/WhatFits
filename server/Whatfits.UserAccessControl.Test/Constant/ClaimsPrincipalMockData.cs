using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.UserAccessControl.Test.Constant
{
    public class ClaimsPrincipalMockData
    {
        public static ClaimsPrincipal NotNullPrincipal()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();


            return principal;
        }

        public static ClaimsPrincipal HasUsername()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();

            Claim username = new Claim("UserName", "latmey");

            ClaimsIdentity ci = new ClaimsIdentity();
            ci.AddClaim(username);

            principal.AddIdentity(ci);

            return principal;
        }
    }
}
