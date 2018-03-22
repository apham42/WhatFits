using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Model.Location;

namespace server.Model.Account
{
    public class RegInfo
    {
        public UserCredential UserCredInfo { get; set; }
        public List<SecurityQuestion> SecurityQandAs { get; set; }
        public Address UserLocation { get; set; }
    }
}