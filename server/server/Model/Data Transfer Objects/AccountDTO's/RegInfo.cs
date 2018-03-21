using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Model.Account;
using server.Model.Address;

namespace server.Model.Data_Transfer_Objects.AccountDTO_s
{
    public class RegInfo
    {
        public UserCredential UserCredInfo { get; set; }
        public SecurityQuestion[] SecurityQandAs { get; set; }
        public Location UserLocation { get; set; }
    }
}