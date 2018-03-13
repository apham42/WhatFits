using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    public class AccountConstants
    {
        public const string CREDCHARACTERS = @"^[A-Za-z\d~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<]+$";

        // username constants
        public const string USERNAME_VALID = "Username is valid";
        public const string USERNAME_EXISTS_ERROR = "Username already exists";
        public const string USERNAME_INVALID_CHARACTERS_ERROR = "Username has invalid special characters";
        public const string USERNAME_SHORT_ERROR = "Username does not reach the minimum length of 8";
        public const string USERNAME_LONG_ERROR = "Username is too long. Maximum length is 64 characters";

        // password constants
        public const string USER_AND_PASSWORD_VALID = "Username and password is valid";
        public const string PASSWORD_SHORT_ERROR = "Password does not reach the minimum length of 8";
        public const string PASSWORD_LONG_ERROR = "Password is too long. Maximum length is 64 characters";
        public const string PASSWORD_INVALID_CHARACTERS_ERROR = "Password has invalid special characters";

        // Address constants
        public const string ADDRESS_INVALID_ERROR = "Address does not exist";
        public const string ADDRESS_CONSTRAINT_ERROR = "Address does not exist in Los Angeles or Orange County";

        // Map Web API info constants
        public const string MAPAPI = @"https://maps.googleapis.com/maps/api/geocode/json?address=";
        public const string MAPKEY = "&key=AIzaSyC2S7VIW4VHNZ1h0qHlBIo4QhbpIAkGgus";
        //~`!@#$%^&*()-_+=\\|\]}\[{'"";:/?.>,<

    }
}