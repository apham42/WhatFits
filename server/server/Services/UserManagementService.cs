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
        /// Changes the status of a user.
        /// </summary>
        /// <param name="obj">
        /// UserName(String), Status(String)
        /// </param>
        /// <returns>
        /// True - If change is successful
        /// False = If change is unsuccessful
        /// </returns>
        public ResponseDTO<Boolean> ChangeUserStatus(UserManagementDTO obj)
        {
            UserManagementGateway userman = new UserManagementGateway();
            ResponseDTO<Boolean> response = new ResponseDTO<bool>();
            switch (obj.Type)
            {
                case "Enable":
                    response = userman.EnableUser(obj);
                    break;
                case "Disable":
                    response = userman.DisableUser(obj);
                    break;
                default:
                    response.IsSuccessful = false;
                    response.Messages.Add("Error: Invalid Status.");
                    break;
            }
            return response;
        }
    }
}