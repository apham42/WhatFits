using System;
using Whatfits.DataAccess.Gateways.CoreGateways;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.DTOs;

namespace server.Services
{
    /// <summary>
    /// Provides the Business Logic behind User Management.
    /// </summary>
    public class UserManagementService
    {
        /// <summary>
        /// 
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
        /// 
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
        /// 
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