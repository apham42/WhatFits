using System;
using System.Text.RegularExpressions;
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
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> EditProfile([FromBody]ProfileDTO obj)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>();
            if (!ValidateProfileData(obj))
            {
                response.IsSuccessful = false;
                response.Messages.Add("Invalid Data");
                return response;
            }
            UserProfileGateway userProfileDb = new UserProfileGateway();
            response = userProfileDb.EditProfile(obj);
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool ValidateProfileData(ProfileDTO obj)
        {
            // FINISH VALIDATIONS. -Rob
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private bool ValidateUserName(string userName)
        {
            Regex reg = new Regex("^[a-zA-Z0-9_]{2,64}$");
            if(reg.IsMatch(userName)|| userName == null)
            {
                return true;
            }
            return false;
        }
    }
}