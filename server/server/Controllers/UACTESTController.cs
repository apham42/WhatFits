using System.Web.Http;
using Whatfits.JsonWebToken.Constant;
using Whatfits.JsonWebToken.Controller;
using Whatfits.UserAccessControl.Auth;

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
            return CreateJWT.CreateToken("apham42");
        }

        [HttpPost]
        public bool three()
        {
            return VerifyJWT.VerifyToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL3d3dy5XaGF0Zml0cy5zb2NpYWwvIiwic3ViIjoiYXBoYW00MiIsImF1ZCI6IkdlbmVyYWwiLCJpYXQiOiIxNTIxNDIxMjY3IiwibmJmIjoiMTUyMTQyMTI2NyIsImV4cCI6IjE1MjE0MjQ4NjciLCJXT1JLT1VUX0FERCI6IkFERCIsIldPUktPVVRfVklFVyI6IlZJRVcifQ.J2BJmCDdvsVhYhH5-g-w4wPsjqUSwNoDHWK4AGZL-xw", Key.secret);
        }


        [HttpGet]
        [TokenAuthorize(claimType = "WORKOUT_ADD", claimValue = "EE")]
        public string four()
        {
            return "FAIL";
        }

    }
}
