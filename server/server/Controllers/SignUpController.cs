using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using server.Services;
using server.Model.Account;
using server.Model.Validators;
using FluentValidation.Results;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;
using server.Model.Network_Communication;
using Whatfits.Hash;
using System.Configuration;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class SignUpController : ApiController
    {
        [HttpPost]
        /// <summary>
        /// Handles Register requests
        /// </summary>
        /// <param name="userCred"> Registeration Information </param>
        /// <returns> Status of the request with a list of messages </returns>
        public IHttpActionResult Register(RegInfo userCred)
        {
            AccountService service = new AccountService();
            RegInfoResponseDTO response = service.CreateUser(userCred);
            if(response.isSuccessful)
            {
                return Ok(new { response.Messages });
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
        }
    }
}
