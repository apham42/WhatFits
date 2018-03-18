using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

using Whatfits.UserAccessControl.Auth;
using Whatfits.JsonWebToken.Controller;
using Whatfits.JsonWebToken.Constant;
using Newtonsoft.Json;

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


        [HttpPost]
        public string two()
        {
            return CreateJWT.CreateToken();
        }

        [HttpPost]
        public string three()
        {
            return VerifyJWT.VerifyToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJc3MiOiJodHRwczovL3d3dy5XaGF0Zml0cy5zb2NpYWwvIiwiSWF0IjoiMy8xNy8xOCA2OjE1OjMzIFBNIiwiRXhwIjoiMy8xNy8xOCA3OjE1OjMzIFBNIn0.cD3o1PR9Vm_p7KlHqdRHJr_rVknfSsqRVRNx7le4Umo", Key.secret);
        }


        [HttpGet]
        [TokenAuthorize(claimType = "WORKOUT_ADD", claimValue = "EE")]
        public string four()
        {
            return "FAIL";
        }

    }
}
