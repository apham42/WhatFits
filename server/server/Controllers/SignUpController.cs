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
        public IHttpActionResult Register(UserCredentials userCred)
        {
            AccountService service = new AccountService();
            //UserCredentials userCred = new UserCredentials(username, password);
            UserCredentialValidator validator = new UserCredentialValidator();
            ValidationResult results = validator.Validate(userCred);
            IList<ValidationFailure> failures = results.Errors;
            List<string> failure = new List<string>();

            foreach (ValidationFailure fail in failures)
            {
                failure.Add(fail.ErrorMessage);
            }

            if(!failures.Any())
            {
                return Ok("Works");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { failure });
            }
            
        }

        [HttpPost]
        public IHttpActionResult Finish(RegInfoDTO userCred)
        {
            return Ok(userCred.UserLocation);
        }


    }
}
