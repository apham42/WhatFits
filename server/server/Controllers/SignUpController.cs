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

            if(!failures.Any())
            {
                return Ok("Works");
            }
            else
            {
                return Ok("Does not work");
            }
            
        }
    }
}
