using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Data_Transfer_Objects.AccountDTO_s
{
    public class UserCredentialDTO
    {
        public string username { get; }
        public string password { get; }
        public string userType { get; }
    }
}