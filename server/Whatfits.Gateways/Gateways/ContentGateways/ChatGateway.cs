using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Whatfits.Models;
using Whatfits.Models.Context.Content;
using Whatfits.DataAccess.DTOs.ContentDTOs;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class ChatGateway
    {
        private ChatContext db = new ChatContext();
        
        bool UserJoin()
        {
            return false;
        }
        bool UserLeave()
        {
            return false;
        }
        bool AddMessage()
        {
            return false;
        }
        bool GetMessage()
        {
            return false;
        }
        bool CleanChatRoom()
        {
            return false;
        }
        public bool DoesUserNameExists(ChatDTO obj)
        {
            // Find username inside database based on obj.UserName
            var foundUserName = (from credentials in db.Credentials
                                 where credentials.UserName == obj.UserName
                                 select credentials.UserName).FirstOrDefault();
            // Checking if it found a user
            if (foundUserName == null)
                // returns false if passed username does not exists in database
                return false;
            else
                // returns true if passed username does exists in database
                return true;
        }
    }
}
