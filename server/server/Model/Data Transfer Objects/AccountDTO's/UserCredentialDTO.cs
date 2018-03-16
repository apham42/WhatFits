using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Data_Transfer_Objects.AccountDTO_s
{
    public class UserCredentialDTO
    {
        public string UserName { get; }
        public string Password { get; }
        public string Signature { get; }
    }
}