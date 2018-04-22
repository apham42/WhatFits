using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs.ContentDTOs;

namespace server.Controllers
{
    /// <summary>
    /// Returns user Data to be displayed
    /// </summary>
    [RoutePrefix("v1/profile")]
    public class UserProfileController : ApiController  
    {
        /// <summary>
        /// Retrieves the user information from the database to the frontend.
        /// </summary>
        /// <returns>
        /// A Profile
        /// </returns>
        [HttpGet]
        [EnableCors("http://localhost:8081 , http://localhost:8080, http://longnlong.com , http://whatfits.social", "*", "GET")]
        public IHttpActionResult GetProfileData()
        {
            // TODO: Validate incoming username to see if it exists in the database
            // TODO: Create a service that gets the required data from the database
            // TODO: Send data back to client side.
            ProfileDTO profile = new ProfileDTO()
            {
                FirstName = "John",
                LastName = "Smith",
                Description = "This is a description, asd;fwefoasdajefasdoasdofhasoi;ejoaisjeosifnasfasuivbasivuabseivuasbv",
                SkillLevel = "Beginner",
                Gender = "Male",
                ProfilePictureDirectory = "../../assets/Images/ProfileDummy/profilePicture.jpg"
            };
            return Content(HttpStatusCode.OK, profile);
        }
    }
}
