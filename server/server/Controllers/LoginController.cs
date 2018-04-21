using server.Business_Logic.Services;
using server.Interfaces;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.JsonWebToken.Controller;

namespace server.Controllers
{
    [RoutePrefix("v1/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult Login([FromBody] UserCredential userCredential)
        {
            LoginResponseDTO response = new LoginResponseDTO();
            ILogin login = new LoginService();

            LoginDTO loginDTO = login.UserCredentialTransformer(userCredential);

            ResponseDTO<LoginDTO> loginResponseDTO = login.GetUsersCredentails(loginDTO);

            if(loginResponseDTO.IsSuccessful == false)
            {
                //response.Messages.Add("User does not exist");
                return Content(HttpStatusCode.NotFound, response.Messages);
            }

            bool validated = login.ValidateCredentials(loginDTO, loginResponseDTO);

            if(validated == false)
            {
                return Content(HttpStatusCode.Unauthorized, response.Messages);
            }

            response = login.GetLoginToken(loginResponseDTO);

            if(response.isSuccessful == false)
            {
                return Content(HttpStatusCode.NotFound, response.Messages);
            }

            return Ok(response);
        }
    }
}
