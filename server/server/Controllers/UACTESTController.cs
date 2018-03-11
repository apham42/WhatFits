using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

using Whatfits.UserAccessControl.Auth;
using Whatfits.JsonWebToken.Controller;

namespace server.Controllers
{
    public class UACTESTController : ApiController
    {

        [HttpPost]
        [TokenAuthorize(claimType = "WORKOUT_ADD", claimValue = "ADD")]
        public string one()
        {
            return "PASS";
        }
        

        [HttpGet]
        [TokenAuthorize(claimType = "WORKOUT_ADD", claimValue = "EE")]
        public string four()
        {
            return "FAIL";
        }
    }
}
