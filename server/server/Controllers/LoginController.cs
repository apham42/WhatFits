using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
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
            string username = userCredential.Username;
            response.username = username;

            LoginDTO loginDTO = new LoginDTO()
            {
                UserName = username
            };

            LoginGateway loginGateway = new LoginGateway();

            ResponseDTO<LoginDTO> loginResponseDTO = loginGateway.GetCredentials(loginDTO);


            if(loginResponseDTO.Data.Type == "Enable")
            {
                CreateJWT createJWT = new CreateJWT();
                response.token = createJWT.CreateToken(username); //, "general");
            }
            
            return Ok(response);
        }
    }
}
