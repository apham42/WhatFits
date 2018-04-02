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
    }
}
