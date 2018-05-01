using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Data_Transfer_Objects.AccountDTO_s
{
    public class TokenRefreshResponseDTO : IResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }

        public string username { get; set; }
        public string token { get; set; }
    }
}