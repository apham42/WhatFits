using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Data_Transfer_Objects.AccountDTO_s
{
    // DTO for gateway
    public class UserCredentialDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Type { get; set; }
    }
}