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
        [EnableCors("http://localhost:8081 , http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
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

        [HttpPost]
        [EnableCors("http://localhost:8081 , http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public async Task<HttpResponseMessage> PostFormData()
        {   
            try
            {
                // Getting an HttpContext Request
                var httpRequest = HttpContext.Current.Request;
                // Getting files from request
                foreach (string file in httpRequest.Files)
                {

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                    // Receiving files from request
                    var imageFile = httpRequest.Files[file];
                    // Checking if there is a valid file to be processed and not emtpy
                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        // Validating max size
                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  
                        // Checking file extension for actual image
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png" };
                        // Extracting file extension for validation
                        var ImageExtension = imageFile.FileName.Substring(imageFile.FileName.LastIndexOf('.')).ToLower();
                        // Making comparison for valid file exe
                        if (!AllowedFileExtensions.Contains(ImageExtension))
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Error: Invalid file extension.");
                        }
                        else if (imageFile.ContentLength > MaxContentLength)
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Error: Invalid image size.");
                        }
                        else
                        {
                            /*
                            // Default way
                            string path = ConfigurationManager.AppSettings["imagePath"];
                            var filePath = HttpContext.Current.Server.MapPath(@""+path + imageFile.FileName);
                            imageFile.SaveAs(filePath);
                            */
                            // Default way
                            string userName = "rsanchez92";
                            string path = ConfigurationManager.AppSettings["imagePath"];
                            var imageExtension = imageFile.FileName.Substring(imageFile.FileName.LastIndexOf('.'));
                            string newFileName = userName + "ProfileImage" + imageExtension;
                            var filePath = HttpContext.Current.Server.MapPath(@"" + path + newFileName);
                            imageFile.SaveAs(filePath);
                        }
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.Created, "Success: Image Uploaded Successfully."); ;
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error: No image found. Did you upload one?");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error: An exception was thrown while processing your request. \n" + e);
            }

        }
    }
}
