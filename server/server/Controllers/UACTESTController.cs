using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Whatfits.UserAccessControl.Auth;
using Whatfits.JsonWebToken.Controller;





namespace server.Controllers
{
    public class UACTESTController : ApiController
    {

        [HttpPost]
        [TokenAuthorize(claimType = "WORKOUT_ADD", claimValue = "ADD")]
        public string TEST()
        {
            var re = Request;
            var header = re.Headers;

            string hey = header.GetValues("Token").First();
            
            return hey;
        }

        [HttpGet]
        public string createToken()
        {
            return CreateJWT.CreateJsonWebToken();
        }
    }
}
