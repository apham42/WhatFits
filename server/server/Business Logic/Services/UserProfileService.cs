using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Business_Logic.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfileService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ResponseDTO<ProfileDTO> GetProfile(UsernameDTO obj)
        {
            // Creates ResponseDTO for transfering data and error messages between layers.
            ResponseDTO<ProfileDTO> response = new ResponseDTO<ProfileDTO>();
            if (!ValidateUserName(obj.Username))
            {
                response.IsSuccessful = false;
                response.Messages.Add("Invalid userName.");
                return response;
            }
            // Creating Profile Gateway to access data
            UserProfileGateway userProfileDb = new UserProfileGateway();
            // sending data from Gateway back to response object
            response = userProfileDb.GetProfile(obj);
            return response;
        }
        /// <summary>
        /// Edits the profile information
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> EditProfile(ProfileDTO obj, HttpPostedFile image)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>();
            // Passing Files into the validations
            if(obj.IsUpdatingProfileImage == "true")
            {
                if (!ValidateImage(image))
                {
                    response.IsSuccessful = false;
                    response.Messages.Add("Invalid Data");
                    return response;
                }
                obj.ProfilePicture = SaveImage(image, obj.UserName);
            }
            if (!ValidateProfileData(obj))
            {
                // Validations failed for at least one of the data
                response.IsSuccessful = false;
                response.Messages.Add("Invalid Data");
                return response;
            }
            // Storing data
            UserProfileGateway userProfileDb = new UserProfileGateway();
            response = userProfileDb.EditProfile(obj);
            return response;
        }
        private string SaveImage(HttpPostedFile image, string userName)
        {
            try
            {
                // Default way
                string path = ConfigurationManager.AppSettings["imagePath"];
                var imageExtension = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                string newFileName = userName + "ProfileImage" + imageExtension;
                var filePath = HttpContext.Current.Server.MapPath(@"" + path + newFileName);
                image.SaveAs(filePath);
                return newFileName;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            
        }
        /// <summary>
        /// Validates all the information passed through DTO
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if passes validations, False if it doesn't</returns>
        private bool ValidateProfileData(ProfileDTO obj)
        {
            // Validate normal text such as first name, last name, and gender
            Regex testReg = new Regex("^[a-zA-Z0-9_]{2,64}$");
            // Testing first name and last name
            if (!testReg.IsMatch(obj.FirstName) || !testReg.IsMatch(obj.LastName))
            {
                return false;
            }
            // Testing skill level to presets
            if(obj.SkillLevel != "Beginner" && obj.SkillLevel != "Intermediate" && obj.SkillLevel != "Advance")
            {
                return false;
            }
            // Testing email based on regex for email validation
            Regex emailReg = new Regex(@"^(?()(.+?(?<!\\)@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`{}|~\w])*)(?<=[0-9a-z])@))(?([)([(\d{1,3}.){3}\d{1,3}])|(([0-9a-z][-0-9a-z]*[0-9a-z]*.)+[a-z0-9][-a-z0-9]{0,22}[a-z0-9]))$");
            if (!emailReg.IsMatch(obj.Email))
            {
                return false;
            }
            // Testing gender for valid characters
            if(!testReg.IsMatch(obj.Gender))
            {
                return false;
            }
            // Testing if description is at proper length
            if(obj.Description.Length > 256)
            {
                return false;
            }
            // Passed user input validation
            return true ;
        }
        /// <summary>
        /// Validates Username
        /// </summary>
        /// <param name="userName">User's Name</param>
        /// <returns>True if passes validations, False if it fails</returns>
        private bool ValidateUserName(string userName)
        {
            Regex reg = new Regex("^[a-zA-Z0-9_]{2,64}$");
            if(reg.IsMatch(userName)|| userName == null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Validates an HttpPostedFile for image properties
        /// </summary>
        /// <param name="image">HttpPostedFile</param>
        /// <returns>True if passes validations, False if fails validations</returns>
        private bool ValidateImage(HttpPostedFile image)
        {
            // Size is aprox 1MB
            int maxContentLength = 1024 * 1024 * 1;
            // Creating a list of valid file extensions, only supporting .jpg and .png
            IList<string> allowedExtensions = new List<string> { ".jpg", ".png" };
            // Extracting file extension
            var imageExtension = image.FileName.Substring(image.FileName.LastIndexOf('.')).ToLower();
            // Comparing if extracted file extension matches with at least one on the list
            if (!allowedExtensions.Contains(imageExtension))
            {
                return false;
            }
            // Comparing if valid size
            else if(image.ContentLength > maxContentLength)
            {
                return false;
            }
            // Image passed validations
            return true;
        }
    }
}