using System.Net;
using System.Web.Http;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using server.Services;
using System.Web.Http.Cors;
using server.Model.Validators.Account_Validator;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
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
        /// <param name="obj"> A userName, password, location, and security questions and anwsers.</param>
        /// <returns>A success or failure message</returns>
        [HttpPost]
        [Route("create")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult CreateAdmin(RegInfo obj)
        {
            AccountService service = new AccountService();
            // Filter if no data was passed
            if (obj == null)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: No valid data.");
            }
            // Pass input through busines rules to see if data is valid}
            
            // TODO: [ ] Validate incoming information with Abram's validations
            // TODO: [ ] Create Service to add user
            // TODO: [ ] Handle Errors if bad information
            return Ok("NOT FUNCTIONAL - STILL IN DEVELOPMENT ");
        }
        /// <summary>
        /// Enables a user to use the system.
        /// </summary>
        /// <param name="obj">A username to chaneg status.</param>
        /// <returns>A success or failure message.</returns>
        [HttpPut]
        [Route("enable")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult EnableUser (UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            // Filter if no username was passed
            if(obj.UserName == null)
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
            if (!service.EnableUser(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to change status.");
            }
            // Everything was successful, returning message
            return Ok("Success: "+obj.UserName +"'s account was enabled.");
        }
        /// <summary>
        /// Disables a user from the system
        /// </summary>
        /// <param name="obj">A username to be disabled.</param>
        /// <returns>A success or failure message.</returns>
        [HttpPut]
        [Route("disable")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult DisableUser(UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            // Filter if no username was passed
            if (obj.UserName == null)
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
            if (!service.DisableUser(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to change status.");
            }
            // Everything was successful, returning message
            return Ok("Success: " + obj.UserName + "'s account was disabled.");
        }
        /// <summary>
        /// Deletes the user credential information in the database.
        /// </summary>
        /// <param name="obj">A username to be deleted.</param>
        /// <returns>A success or failure message.</returns>
        [HttpPut]
        [Route("delete")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "PUT")]
        public IHttpActionResult DeleteUser (UserManagementDTO obj)
        {
            UserManagementService service = new UserManagementService();
            if(obj.UserName == null)
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
            if (!service.DeleteUser(obj).IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest, "Failure: Failed to delete user.");
            }
            // Everything was successful, returning message
            return Ok("Success: " + obj.UserName+" was deleted.");
        }
        // NOTE: Used for testing Purposes, will be deleted once done -Rob

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("samplePost")]
        [EnableCors("http://localhost:8081 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult TestPost(UserManagementDTO obj)
        {
            if (obj == null)
            {
                return Content(HttpStatusCode.BadRequest,"Forgot to add data.");
            }
            else
            {
                return Ok("This has executed Correctly." + obj.FirstName +" "+obj.LastName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sampleGet")]
        [EnableCors("http://localhost:8081  , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult getTest()
        {
            return Ok( 
                new UserManagementDTO {
                    FirstName = "Adam",
                    LastName = "West"
                }
            );
        }
    }
}
