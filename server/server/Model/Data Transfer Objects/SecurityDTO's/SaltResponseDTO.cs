using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Model.Data_Transfer_Objects.SecurityDTO_s
{
    public class SaltResponseDTO : IResponseDTO
    {
        public string Salt { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}