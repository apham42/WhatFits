using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Context.Content;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using System.Data.SqlClient;
using System.Data;
using Whatfits.DataAccess.Constants;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class SearchGateway
    {
        private SearchContext db = new SearchContext();

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
                    messages.Add(AccountGatewayConstants.USER_DNE_ERROR);
                    response.Messages = messages;
                }
            }
            catch (SqlException)
            {
                response.isSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
                response.Messages = messages;
            }
            catch (DataException)
            {
                response.isSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
                response.Messages = messages;
            }
            return response;
        }

    }
}
