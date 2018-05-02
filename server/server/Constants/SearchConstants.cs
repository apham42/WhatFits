using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    public class SearchConstants
    {
        public const string NO_CRITERIA_ERROR = "Please enter a search criteria";
        public const string NO_REQUESTEDBY_ERROR = "You are not authorized to perform this search";

        // Search User errors
        public const string NO_REQUESTED_USER_ERROR = "You did not enter a username to search for";
        public const string NO_USER_ERROR = "The username you provided does not exist";

        // Search Criteria errors
        public const string NO_NEARBY_USERS_ERROR = "There are no users around the address you have provided";
        public const string USERS_FOUND_ERROR = "Users were found around your area";
        public const string NO_SKILL_ERROR = "You did not enter a skill";
        public const string NO_DISTANCE_ERROR = "You did not enter a valid distance";
        public const string NO_REQUESTED_SEARCH_ERROR = "You did not enter a valid address for search";

        public const string USER_FOUND = "The user that you requested was found";
    }
}