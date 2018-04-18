using System;
using System.Web.Http;
using Whatfits.UserAccessControl.Controller;
using Whatfits.Hash;
using System.Collections;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using Whatfits.JsonWebToken.Controller;
using System.Collections.Generic;

namespace server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UACTESTController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[AuthorizePrincipal(type = "Workout", value = "add workout")]
        public bool one()
        {
            ICollection<int> hey = new List<int>();

            HMAC256 createnewsecret = new HMAC256();
            byte[] byt = Convert.FromBase64String(createnewsecret.GenerateSalt());
            string test = Convert.ToBase64String(byt);
            byte[] byt2 = Convert.FromBase64String(test);

            return StructuralComparisons.StructuralEqualityComparer.Equals(byt, byt2);
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string five()
        {
            CreateJWT createJWT = new CreateJWT();

            return createJWT.CreateToken("amay", "general");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthorizePrincipal(type = "WORKOUT_ADD", value = "Add")]
        public string six()
        {
            return "Pass";
        }

    }
}
