using System;
using System.Web.Http;
using Whatfits.UserAccessControl.Controller;
using Whatfits.Hash;
using System.Collections;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;

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
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "EE")]
        public string four()
        {
            return "FAIL";
        }

    }
}
