using System.Net;
using System.Web.Http;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using server.Services;
using System.Web.Http.Cors;
using server.Model.Validators.Account_Validator;
using server.Model.Account;

namespace server.Controllers
{
    /// <summary>
    /// Provides APIs for UserManagement for Clientside
    /// </summary> 
    [RoutePrefix("v1/management")]
    public class UserManagementController : ApiController
    {
        /// <summary>
        /// Creates an admin for the system from the usermanagement console.
        /// </summary>
        /// <param name="obj"> A userName(string), password(string), address(string), city(string), zipcode(string), state(string), and security questions and anwsers.(string)</param>
        /// <returns>A success or failure message</returns>
        [HttpPost]
        [Route("create")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult CreateAdmin([FromBody] RegInfo obj)
        {
            // Verify if object is not null or invalid
            if (obj == null || !ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Invalid Data being received.");
            }
            // Create service to handle request
            AccountService service = new AccountService();
            // Send DTO to service to be processed
            var response = service.RegisterAdmin(obj);
            // Was processing successful?
            if (!response.isSuccessful)
            {
                // Return bad request, something went wrong in the service
                return Content(HttpStatusCode.BadRequest, new { response.Messages});
            }
            else
            {
                // Return Created status, user was created
                return Content(HttpStatusCode.Created, new { response.Messages});
            }
        }
        /// <summary>
        /// Enables a user to use the system.
        /// </summary>
        /// <param name="obj">A username to chaneg status.</param>
        /// <returns>A success or failure message.</returns>
        [HttpPut]
        [Route("enable")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult EnableUser ([FromBody] UserManagementDTO obj)
        {
            // Filter if no username was passed
            if(obj.UserName == null || !ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: No valid data.");

            }
            // Pass input through business rules to see if a valid username was passed
            RegInfoValidator validator = new RegInfoValidator();
            if (!validator.ValidateUserName(obj.UserName))
            {
                return Content(HttpStatusCode.BadRequest, "Failure: No valid data.");
            }
            // Implement the actual status change of that user
            UserManagementService service = new UserManagementService();
            var response = service.EnableUser(obj);
            if (!response.IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, response.Messages);
            }
            // Everything was successful, returning message
            return Content(HttpStatusCode.OK, "Success: Account was enabled for " + obj.UserName);
        }
        /// <summary>
        /// Disables a user from the system
        /// </summary>
        /// <param name="obj">A username to be disabled.</param>
        /// <returns>A success or failure message.</returns>
        [HttpPut]
        [Route("disable")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult DisableUser([FromBody] UserManagementDTO obj)
        {
            // Filter if no username was passed
            if (obj.UserName == null || !ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Bad Request");
            }
            // Pass input through business rules to see if a valid username was passed
            RegInfoValidator validator = new RegInfoValidator();
            if (!validator.ValidateUserName(obj.UserName))
            {
                return Content(HttpStatusCode.BadRequest, "Failure: No valid data.");
            }
            // Implement the actual status change of that user
            UserManagementService service = new UserManagementService();
            var response = service.DisableUser(obj);
            if (!response.IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, response.Messages);
            }
            // Everything was successful, returning message
            return Content(HttpStatusCode.OK, "Success: Account was disabled for " + obj.UserName);
        }
        /// <summary>
        /// Deletes the user credential information in the database.
        /// </summary>
        /// <param name="obj">A username to be deleted.</param>
        /// <returns>A success or failure message.</returns>
        [HttpPut]
        [Route("delete")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult DeleteUser ([FromBody] UserManagementDTO obj)
        {
            if(obj.UserName == null || !ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Bad Request");
            }
            // Pass input through business rules to see if a valid username was passed
            RegInfoValidator validator = new RegInfoValidator();
            if (!validator.ValidateUserName(obj.UserName))
            {
                return Content(HttpStatusCode.BadRequest, "Failure: No valid data.");
            }
            // Implement the actual deletion of that uesr
            UserManagementService service = new UserManagementService();
            var response = service.DeleteUser(obj);
            if (!response.IsSuccessful)
            {
                return Content(HttpStatusCode.InternalServerError, response.Messages);
            }
            // Everything was successful, returning message
            return Content(HttpStatusCode.OK, "Success: Account was deleted for " + obj.UserName);
        }
    }
}
