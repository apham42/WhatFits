using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Model.Data_Transfer_Objects.AccountDTO_s
{
    public class UserCredResponseDTO: IResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }
    }
}