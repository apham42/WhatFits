using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    public class AccountConstants
    {
        public const String MAPAPI = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
        public const String MAPKEY = "&key=AIzaSyC2S7VIW4VHNZ1h0qHlBIo4QhbpIAkGgus";
        //~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<
        public const String CREDCHARACTERS = @"^[A-Za-z\d~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<]+$";
    }
}