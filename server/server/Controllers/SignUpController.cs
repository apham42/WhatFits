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
        public IHttpActionResult Register(RegInfoDTO userCred)
        {
            AccountService service = new AccountService();
            //UserCredentials userCred = new UserCredentials(username, password);
            //UserCredentialValidator validator = new UserCredentialValidator();
            UserCredResponseDTO response = service.ValidateRegInfo(userCred);
            /**
            if (userCred == null)
            {
                return Content(HttpStatusCode.BadRequest, "ASD");
            }
            ValidationResult results = validator.Validate(userCred);
            IList<ValidationFailure> failures = results.Errors;
            List<string> messages = new List<string>();

            foreach (ValidationFailure fail in failures)
            {
                messages.Add(fail.ErrorMessage);
            }
            **/
            if(response.isSuccessful)
            {
                return Ok("Works");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { response.Messages });
            }
            
        }

        [HttpPost]
        public IHttpActionResult Finish(UsernameDTO username)
        {
            RegistrationGateway gateway = new RegistrationGateway();
            var status = gateway.CheckUserName(username);
            //var status = gateway.GetUserList();
            return Ok(new {status});
        }

        [HttpPost]
        public IHttpActionResult Google([FromBody] string url)
        {
   
            var network = new GoogleMapComm();
            //var result = Task.Run(async () => { return await network.Request("1600 + Amphitheatre + Parkway,+Mountain + View,+CA"); }).Result;

            //var result = Task.Run(() => network.Request("1600 + Amphitheatre + Parkway,+Mountain + View,+CA")).Result;
            //var r = await Task.WhenAll(status.Request("1600 + Amphitheatre + Parkway,+Mountain + View,+CA"));
            //string result = network.Request("1600 + Amphitheatre + Parkway,+Mountain + View,+CA").GetAwaiter().GetResult();
            network.test();
            System.Threading.Thread.Sleep(3000);
            return Ok(network.result );
        }

    }
}
