using System;
using System.Linq;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.Models.Context.Core;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfileGateway
    {
        private AccountContext db = new AccountContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ResponseDTO<ProfileDTO> GetProfile(UsernameDTO obj)
        {
            ResponseDTO<ProfileDTO> response = new ResponseDTO<ProfileDTO>();
            var foundProfile = (from user in db.Credentials
                             join profile in db.UserProfiles
                                on user.UserID equals profile.UserID
                             where user.UserName == obj.Username
                                select profile).FirstOrDefault();
            if (foundProfile == null)
            {
                // Return failure in responseDTO
                response.IsSuccessful = false;
                response.Data = null;
                return response;
            }
            // Found user, sending data back to frontend
            response.Data = new ProfileDTO(foundProfile.FirstName,foundProfile.LastName,foundProfile.Description,foundProfile.SkillLevel, foundProfile.Email, foundProfile.Gender,foundProfile.ProfilePicture);
            response.IsSuccessful = true;
            response.Messages.Add("User Found, retrieving data.");
            return response;
        }
        public ResponseDTO<bool> EditProfile(ProfileDTO obj)
        {
            ResponseDTO<bool> response = new ResponseDTO<bool>();
            var foundProfile = (from user in db.Credentials
                                join profile in db.UserProfiles
                                   on user.UserID equals profile.UserID
                                where user.UserName == obj.UserName
                                select profile).FirstOrDefault();
            if (foundProfile == null)
            {
                // Return failure in responseDTO
                response.IsSuccessful = false;
                return response;
            }
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Edit values for profile
                    foundProfile.FirstName = obj.FirstName;
                    foundProfile.LastName = obj.LastName;
                    foundProfile.Description = obj.Description;
                    foundProfile.Gender = obj.Gender;
                    foundProfile.Email = obj.Email;
                    foundProfile.SkillLevel = obj.SkillLevel;
                    foundProfile.ProfilePicture = obj.ProfilePicture;
                    // Saves changes
                    db.SaveChanges();
                    // Commits if works
                    dbTransaction.Commit();
                    // Inform other layer that it succeeded
                    response.IsSuccessful = true;
                    return response;
                }
                catch (Exception)
                {
                    // undo any changes if errors
                    dbTransaction.Rollback();
                    // Inform other layer about failure
                    response.IsSuccessful = false;
                    return response;
                }
            }
        }
    }
}
