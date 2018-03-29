using System.Web.Http;
using Whatfits.JsonWebToken.Constant;
using Whatfits.JsonWebToken.Controller;
using Whatfits.UserAccessControl.Controller;

namespace server.Controllers
{
    public class UACTESTController : ApiController
    {
        [HttpPost]
        [AuthorizePrincipal(type = "Workout", value = "add workout")]
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
        //public string three()
        //{
        //    return 
        //}


        [HttpGet]
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "EE")]
        public string four()
        {
            return "FAIL";
        }

    }
}
