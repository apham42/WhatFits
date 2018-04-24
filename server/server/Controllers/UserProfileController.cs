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
            if (!response.IsSuccessful)
            {
                return Content(HttpStatusCode.BadRequest,"Error: " + response.Messages);
            }
            return Content(HttpStatusCode.OK, "Operation was successful? "+response.IsSuccessful);
        }
        [HttpGet]
        [EnableCors("http://localhost:8080 , http://localhost:8081  , http://longnlong.com , http://whatfits.social", "*", "GET")]
        public IHttpActionResult GetProfileData()
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
        [HttpPost]
        [EnableCors("http://localhost:8080 , http://localhost:8081  , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public async Task<HttpResponseMessage> StoreImage()
        {
            /*
            if (obj.ProfilePicture == null)
            {
                return Content(HttpStatusCode.BadRequest, "This is null");
            }
            return Content(HttpStatusCode.OK, "This filename was passed through:" + obj.ProfilePicture);
            */
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            var message = string.Format("Please Upload image of type .jpg,.png.");
                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");
                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            string path = ConfigurationManager.AppSettings["imagePath"];
                            //string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\Data\"));
                            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\Data\")); 
                            //var filePath = HttpContext.Current.Server.MapPath(newPath + postedFile.FileName + extension); 
                            var filePath = HttpContext.Current.Server.MapPath(path + postedFile.FileName);
                            //var filePath = path + postedFile.FileName;                            
                            postedFile.SaveAs(filePath);
                        }
                    }
                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception e)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }
    }
}
