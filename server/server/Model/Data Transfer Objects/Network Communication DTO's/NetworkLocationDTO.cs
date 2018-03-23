using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Data_Transfer_Objects.Network_Communication_DTO_s
{
    /// <summary>
    /// Contains the information that is needed to make a request to the map web api
    /// </summary>
    public class NetworkLocationDTO
    {
        public string Location { get; set; }
    }
}