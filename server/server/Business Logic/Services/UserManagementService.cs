using System;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;
using server.Model.Validators.Account_Validator;

namespace server.Services
{
    /// <summary>
    /// Provides the Business Logic behind User Management.
    /// </summary>
    public class UserManagementService
    {
        /// <summary>
        /// Creates an administrator
        /// </summary>
        /// <returns></returns>
        public ResponseDTO<Boolean> CreateAdmin()
        {
            // TODO: Complete creation of admin
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            return response;
        }
        
        /// <summary>
        /// Enables a user in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> EnableUser(UserManagementDTO obj)
        {
            UserManagementGateway userman = new UserManagementGateway();
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            response = userman.EnableUser(obj);
            return response;
        }
        /// <summary>
        /// Disables a user
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> DisableUser(UserManagementDTO obj)
        {
            UserManagementGateway userman = new UserManagementGateway();
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            response = userman.DisableUser(obj);
            return response;
        }
        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResponseDTO<Boolean> DeleteUser(UserManagementDTO obj)
        {
            UserManagementGateway userman = new UserManagementGateway();
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            response = userman.DeleteUser(obj);
            return response;
        }
    }
}