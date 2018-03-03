using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace Whatfits.UserAccessControl.Constants
{
    static public class ClaimConstants
    {

        public static List<Claim> DEFAULT_CLAIMS = new List<Claim>()
        {
                new Claim(WORKOUTLOG_CLAIM_TYPE_ADD, WORKOUTLOG_CLAIM_VALUE_ADD),
                new Claim(WORKOUTLOG_CLAIM_TYPE_VIEW, WORKOUTLOG_CLAIM_VALUE_VIEW),
                new Claim(WORKOUTLOG_CLAIM_TYPE_EDIT, WORKOUTLOG_CLAIM_VALUE_EDIT),
                new Claim(WORKOUTLOG_CLAIM_TYPE_DELETE, WORKOUTLOG_CLAIM_VALUE_DELETE),
                new Claim(SEARCH_CLAIM_TYPE, SEARCH_CLAIM_VALUE),
                new Claim(CHAT_CLAIM_TYPE, CHAT_CLAIM_VALUE),
                new Claim(FOLLOW_CLAIM_TYPE, FOLLOW_CLAIM_VALUE),
                new Claim(FOLLOWERSLIST_CLAIM_TYPE, FOLLOWERSLIST_CLAIM_VALUE),
                new Claim(RATE_CLAIM_TYPE, RATE_CLAIM_VALUE),
                new Claim(REVIEW_CLAIM_TYPE, REVIEW_CLAIM_VALUE),
                new Claim(EVENT_CLAIM_TYPE_ADD, EVENT_CLAIM_VALUE_ADD),
                new Claim(EVENT_CLAIM_TYPE_DELETE, EVENT_CLAIM_VALUE_DELETE),
                new Claim(EVENT_CLAIM_TYPE_EDIT, EVENT_CLAIM_VALUE_EDIT),
                new Claim(EVENT_CLAIM_TYPE_VIEW, EVENT_CLAIM_VALUE_VIEW)
        };
        // WORKOUTLOG CLAIMS
        // private const int WORKOUTLOG_CLAIM_ADD_ID = 1;
        private const string WORKOUTLOG_CLAIM_TYPE_ADD = "WORKOUT_ADD";
        private const string WORKOUTLOG_CLAIM_VALUE_ADD = "Add";

        // private const int WORKOUTLOG_CLAIM_VIEW_ID = 2;
        private const string WORKOUTLOG_CLAIM_TYPE_VIEW = "WORKOUT_VIEW";
        private const string WORKOUTLOG_CLAIM_VALUE_VIEW = "View";

        // private const int WORKOUTLOG_CLAIM_EDIT_ID = 3;
        private const string WORKOUTLOG_CLAIM_TYPE_EDIT = "WORKOUT_EDIT";
        private const string WORKOUTLOG_CLAIM_VALUE_EDIT = "Edit";

        // private const int WORKOUTLOG_CLAIM_DELETE_ID = 4;
        private const string WORKOUTLOG_CLAIM_TYPE_DELETE = "WORKOUT_DELETE";
        private const string WORKOUTLOG_CLAIM_VALUE_DELETE = "Delete";

        // SEARCH CLAIMS
        // private const int SEARCH_CLAIM_ADD_ID = 5;
        private const string SEARCH_CLAIM_TYPE = "SEARCH";
        private const string SEARCH_CLAIM_VALUE = "True";

        // CHAT CLAIMS
        // private const int CHAT_CLAIM_ID = 6;
        private const string CHAT_CLAIM_TYPE = "CHAT";
        private const string CHAT_CLAIM_VALUE = "True";

        // FOLLOW CLAIMS
        // private const int FOLLOW_CLAIM_ID = 7;
        private const string FOLLOW_CLAIM_TYPE = "FOLLOW";
        private const string FOLLOW_CLAIM_VALUE = "True";

        // private const int FOLLOWERSLIST_CLAIM_ID = 8;
        private const string FOLLOWERSLIST_CLAIM_TYPE = "FOLLOWERSLIST";
        private const string FOLLOWERSLIST_CLAIM_VALUE = "True";

        // RATE CLAIMS
        // private const int RATE_CLAIM_ID = 9;
        private const string RATE_CLAIM_TYPE = "RATE";
        private const string RATE_CLAIM_VALUE = "True";

        // REVIEW CLAIMS
        // private const int REVIEW_CLAIM_ID = 10;
        private const string REVIEW_CLAIM_TYPE = "REVIEW";
        private const string REVIEW_CLAIM_VALUE = "True";

        // EVENT CLAIMS
        // private const int EVENT_CLAIM_ADD_ID = 11;
        private const string EVENT_CLAIM_TYPE_ADD = "EVENT_ADD";
        private const string EVENT_CLAIM_VALUE_ADD = "Add";

        // private const int EVENT_CLAIM_VIEW_ID = 12;
        private const string EVENT_CLAIM_TYPE_VIEW = "EVENT_VIEW";
        private const string EVENT_CLAIM_VALUE_VIEW = "View";

        // private const int EVENT_CLAIM_EDIT_ID = 13;
        private const string EVENT_CLAIM_TYPE_EDIT = "EVENT_EDIT";
        private const string EVENT_CLAIM_VALUE_EDIT = "Edit";

        // private const int EVENT_CLAIM_DELETE_ID = 14;
        private const string EVENT_CLAIM_TYPE_DELETE = "EVENT_DELETE";
        private const string EVENT_CLAIM_VALUE_DELETE = "Delete";

    }
}