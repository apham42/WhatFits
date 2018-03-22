using System.Web.Http;
using Whatfits.JsonWebToken.Constant;
using Whatfits.JsonWebToken.Controller;
using Whatfits.UserAccessControl.Controller;

namespace server.Controllers
{
    public class UACTESTController : ApiController
    {

        [HttpPost]
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "EE")]
        public string one()
        {
            return "PASS";
        }


        [HttpPost]
        [AllowAnonymous]
        public string two()
        {
            return CreateJWT.CreateToken("apham42");
        }

        //[HttpPost]
        //public ClaimsPrincipal three()
        //{
        //    return VerifyJWT.VerifyToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL3d3dy5XaGF0Zml0cy5zb2NpYWwvIiwic3ViIjoiYXBoYW00MiIsImF1ZCI6IkdlbmVyYWwiLCJpYXQiOiIxNTIxNDIxMjY3IiwibmJmIjoiMTUyMTQyMTI2NyIsImV4cCI6IjE1MjE0MjQ4NjciLCJXT1JLT1VUX0FERCI6IkFERCIsIldPUktPVVRfVklFVyI6IlZJRVcifQ.J2BJmCDdvsVhYhH5-g-w4wPsjqUSwNoDHWK4AGZL-xw");
        //}


        [HttpGet]
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "EE")]
        public string four()
        {
            return "FAIL";
        }

    }
}
