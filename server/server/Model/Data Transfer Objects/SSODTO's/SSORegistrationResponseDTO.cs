using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Data_Transfer_Objects.SSODTO_s
{
    public class SSORegistrationResponseDTO : IResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
    }
}