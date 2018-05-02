using server.Business_Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using System.IO;
using System.Diagnostics;
using Whatfits.UserAccessControl.Controller;
using Whatfits.UserAccessControl.Constants;
using server.Controllers.Constants;

namespace server.Controllers
{
    /// <summary>
    /// Returns user Data to be displayed
    /// </summary>
    [RoutePrefix("v1/UserProfile")]
    public class UserProfileController : ApiController  
    {
        /// <summary>
        /// Retrieves the user information from the database to the frontend.
        /// </summary>
        /// <returns>
        /// A Profile
        /// </returns>
        [HttpPost]
        [AuthorizePrincipal(type = TypeConstant.VIEW_PAGE, value = ValueConstant.VIEW_PAGE_CLAIM_VALUE_PROFILE)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, "POST")]
        public IHttpActionResult ProfileData([FromBody] UsernameDTO obj)
        {
            // Creates service to handle request
            UserProfileService temp = new UserProfileService();
            var response = temp.GetProfile(obj);
            // Was the request handled?
            if (!response.IsSuccessful)
            {
                // Return failure notice to front end
                return Content(HttpStatusCode.NotFound,"Error: " + response.Messages);
            }
            // Request was handled, sending success to front end with data
            return Content(HttpStatusCode.OK, response.Data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AuthorizePrincipal(type = TypeConstant.WORKOUTLOG_CLAIM_TYPE_ADD, value = ValueConstant.WORKOUTLOG_CLAIM_VALUE_ADD)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, "POST")]
        public IHttpActionResult EditProfile()
        {
            // Passing information from form to DTO
            ProfileDTO obj = new ProfileDTO();
            obj.UserName = HttpContext.Current.Request.Params["UserName"];
            obj.FirstName = HttpContext.Current.Request.Params["FirstName"];
            obj.LastName = HttpContext.Current.Request.Params["LastName"];
            obj.Email = HttpContext.Current.Request.Params["Email"];
            obj.Description = HttpContext.Current.Request.Params["Description"];
            obj.SkillLevel = HttpContext.Current.Request.Params["SkillLevel"];
            obj.Gender = HttpContext.Current.Request.Params["Gender"];
            obj.ProfilePicture = HttpContext.Current.Request.Params["ProfilePicture"];
            // Checking if profile image is being updated
            obj.IsUpdatingProfileImage = HttpContext.Current.Request.Params["IsThereImage"];
            HttpPostedFile imageFile = null;
            // Creates service to handle request
            UserProfileService service = new UserProfileService();
            
            // Get image if being updated
            if (obj.IsUpdatingProfileImage == "true")
            {
                imageFile = HttpContext.Current.Request.Files[0];
            }
            // Pressing request
            var response = service.EditProfile(obj, imageFile);
            // Was it successful?
            if (!response.IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest,"Error: " + response.Messages);
            }
            return Content(HttpStatusCode.OK, "Operation was successful? "+ response.IsSuccessful);
        }
    }
}
