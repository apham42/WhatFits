using server.Business_Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.DTOs.CoreDTOs;

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
        [EnableCors("http://localhost:8081 , http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult ProfileData([FromBody]UsernameDTO obj)
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
        [HttpPost]
        [EnableCors("http://localhost:8081 , http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public IHttpActionResult EditProfile(ProfileDTO obj)
        {
            // Creates service to handle request
            UserProfileService temp = new UserProfileService();
            var response = temp.EditProfile(obj);
            
            ProfileDTO profile = new ProfileDTO()
            {
                UserName = "amay",
                FirstName = "John",
                LastName = "Smith",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis nunc ac arcu congue luctus. Nulla ligula sapien, sodales fringilla ligula sit amet, gravida sagittis turpis. Nunc tincidunt est vel risus lobortis laoreet. Suspendisse feugiat metus ac egestas tempor.",
                SkillLevel = "Beginner",
                Gender = "Male",
                ProfilePicture = "../../assets/Images/ProfileDummy/profilePicture.jpg"
            };
            
            return Content(HttpStatusCode.OK, "Operation was: "+response.IsSuccessful);
        }
        [HttpGet]
        [EnableCors("http://localhost:8081 , http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "GET")]
        public IHttpActionResult GetDummy()
        {
            ProfileDTO profile = new ProfileDTO()
            {
                FirstName = "John",
                LastName = "Smith",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis nunc ac arcu congue luctus. Nulla ligula sapien, sodales fringilla ligula sit amet, gravida sagittis turpis. Nunc tincidunt est vel risus lobortis laoreet. Suspendisse feugiat metus ac egestas tempor.",
                SkillLevel = "Beginner",
                Gender = "Male",
                ProfilePicture = "../../assets/Images/ProfileDummy/profilePicture.jpg"
            };
            return Content(HttpStatusCode.OK, profile);
        }
    }
}
