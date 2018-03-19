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

namespace server.Controllers
{
    public class SignUpController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Register(UserCredInfo userCred)
        {
            AccountService service = new AccountService();
            //UserCredentials userCred = new UserCredentials(username, password);
            UserCredentialValidator validator = new UserCredentialValidator();
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

            if(!messages.Any())
            {
                return Ok("Works");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { userCred.Username });
            }
            
        }

        [HttpPost]
        public IHttpActionResult Finish(RegInfoDTO userCred)
        {
            return Ok(userCred.UserLocation);
        }


    }
}
