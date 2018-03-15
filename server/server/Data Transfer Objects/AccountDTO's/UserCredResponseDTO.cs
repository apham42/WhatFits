using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Data_Transfer_Objects.AccountDTO_s
{
    public class UserCredResponseDTO: IResponseDTO
    {
        public string message { get; set; }
        public bool status { get; set; }
    }
}