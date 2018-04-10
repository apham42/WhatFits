using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Model.Location;

namespace server.Model.Account
{
    /// <summary>
    /// Contains the data that is needed for registration
    /// </summary>
    public class RegInfo
    {
        public UserCredential UserCredInfo { get; set; }
        public List<SecurityQuestion> SecurityQandAs { get; set; }
        public Address UserLocation { get; set; }
        public string UserType { get; set; }
    }
}