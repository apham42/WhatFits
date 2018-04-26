using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    public class LocationConstants
    {
        public const string ADDRESS_EMPTY_ERROR = "You did not provide an address";
        public const string ADDRESS_DOESNT_EXIST_ERROR = "Your address does not exist";
        public const string STREET_DOESNT_EXIST_ERROR = "Street does not exist";
        public const string CITY_DOESNT_EXIST_ERROR = "City does not exist";
        public const string STATE_DOESNT_EXIST_ERROR = "State does not exist";
        public const string ZIP_DOESNT_EXIST_ERROR = "Zip code does not exist";
        public const string ADDRESS_NOT_VALID_ERROR = "Address must be in Los Angeles County or Orange County";
    }
}