using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Context.Core;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System.Data.SqlClient;
using System.Data;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class SearchGateway
    {
        private AccountContext db = new AccountContext();

        public UsernameResponseDTO SearchUser(UsernameDTO dto)
        {
            UsernameResponseDTO response = new UsernameResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                string username = (from x in db.Credentials
                                   where x.UserName == dto.Username
                                   select x.UserName).FirstOrDefault();
                if (dto.Username == username)
                {
                    response.isSuccessful = true;
                }
                else
                {
                    response.isSuccessful = false;
                    messages.Add("Username does not exist. Please try again");
                    response.Messages = messages;
                }
            }
            catch (SqlException)
            {
                response.isSuccessful = false;
                messages.Add("Your request could not be made. Please try again.");
                response.Messages = messages;
            }
            catch (DataException)
            {
                response.isSuccessful = false;
                messages.Add("Your request could not be made. Please try again.");
                response.Messages = messages;
            }
            return response;
        }

    }
}
