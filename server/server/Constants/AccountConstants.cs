using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    public class AccountConstants
    {
        public const String CREDCHARACTERS = @"^[A-Za-z\d~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<]+$";
       
        // username errors
        public const String USERNAME_EXISTS_ERROR = "Username already exists";
        public const String USERNAME_INVALID_CHARACTERS_ERROR = "Username has invalid special characters";
        public const String USERNAME_SHORT_ERROR = "Username does not reach the minimum length of 8";
        public const String USERNAME_LONG_ERROR = "Username is too long. Maximum length is 64 characters";

        // password errors
        public const String PASSWORD_SHORT_ERROR = "Password does not reach the minimum length of 8";
        public const String PASSWORD_LONG_ERROR = "Password is too long. Maximum length is 64 characters";

        // Address errors
        public const String ADDRESS_INVALID_ERROR = "Address does not exist";
        public const String ADDRESS_CONSTRAINT_ERROR = "Address does not exist in Los Angeles or Orange County";

        // Map Web API info
        public const String MAPAPI = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
        public const String MAPKEY = "&key=AIzaSyC2S7VIW4VHNZ1h0qHlBIo4QhbpIAkGgus";
        //~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<

    }
}