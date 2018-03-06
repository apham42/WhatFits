using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Whatfits.Models;
using Whatfits.Models.Context.Content;

namespace Whatfits.DataAccess.Gate
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
    }
}
