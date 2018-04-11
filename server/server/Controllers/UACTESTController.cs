using System;
using System.Web.Http;
using Whatfits.UserAccessControl.Controller;
using Whatfits.Hash;
using System.Collections;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using Whatfits.JsonWebToken.Controller;

namespace server.Controllers
{
    public class UACTESTController : ApiController
    {
        [HttpPost]
        //[AuthorizePrincipal(type = "Workout", value = "add workout")]
        public bool one()
        {
            HMAC256 createnewsecret = new HMAC256();
            byte[] byt = Convert.FromBase64String(createnewsecret.GenerateSalt());
            string test = Convert.ToBase64String(byt);
            byte[] byt2 = Convert.FromBase64String(test);

            return StructuralComparisons.StructuralEqualityComparer.Equals(byt, byt2);
        }


        [HttpPost]
        public void two()
        {
            LoginGateway auth = new LoginGateway();
            LoginDTO newDTO = new LoginDTO()
            {
                UserName = "latmey",
                Token = "TOKEN4",
                Salt = "Salt4"
            };

            auth.AddToTokenList(newDTO);
        }

        [HttpGet]
        public string three()
        {
            LoginGateway auth = new LoginGateway();
            LoginDTO dto = new LoginDTO()
            {
                UserName = "latmey"
            };
            ResponseDTO<string> sup = auth.GetSaltFromTokenList(dto);
            return sup.Data;
        }


        [HttpGet]
        //[AuthorizePrincipal(type = "WORKOUT_ADD", value = "EE")]
        public bool four()
        {
            UserAccessDTO userAccessDTO = new UserAccessDTO()
            {
                UserName = "amay",
                UserClaims = UserAccessController.SetDefaultClaims()
            };
            UserAccessControlGateway uac = new UserAccessControlGateway();

            ResponseDTO<Boolean> found = uac.AddUserClaims(userAccessDTO);
            return found.IsSuccessful;
        }

        [HttpGet]
        public string five()
        {
            CreateJWT createJWT = new CreateJWT();

            return createJWT.CreateToken("amay", "general");

        }

        [HttpGet]
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "Add")]
        public string six()
        {
            return "Pass";
        }

    }
}
