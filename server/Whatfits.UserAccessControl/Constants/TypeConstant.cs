using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatfits.UserAccessControl.Constants
{
    public static class TypeConstant
    {
        // WORKOUTLOG TYPE
        public const string WORKOUTLOG_CLAIM_TYPE_ADD = "WORKOUT_ADD";
        public const string WORKOUTLOG_CLAIM_TYPE_VIEW = "WORKOUT_VIEW";
        public const string WORKOUTLOG_CLAIM_TYPE_EDIT = "WORKOUT_EDIT";
        public const string WORKOUTLOG_CLAIM_TYPE_DELETE = "WORKOUT_DELETE";

        // SEARCH TYPE
        public const string SEARCH_CLAIM_TYPE = "SEARCH";

        // CHAT TYPE
        public const string CHAT_CLAIM_TYPE = "CHAT";

        // FOLLOW TYPE
        public const string FOLLOW_CLAIM_TYPE = "FOLLOW";
        public const string FOLLOWERSLIST_CLAIM_TYPE = "FOLLOWERSLIST";

        // RATE TYPE
        public const string RATE_CLAIM_TYPE = "RATE";

        // REVIEW TYPE
        public const string REVIEW_CLAIM_TYPE = "REVIEW";

        // EVENT TYPE
        public const string EVENT_CLAIM_TYPE_ADD = "EVENT_ADD";
        public const string EVENT_CLAIM_TYPE_VIEW = "EVENT_VIEW";
        public const string EVENT_CLAIM_TYPE_EDIT = "EVENT_EDIT";
        public const string EVENT_CLAIM_TYPE_DELETE = "EVENT_DELETE";

        // VIEW PAGE TYPE
        // VIEW PROFILE AND EDIT PROFILE PAGE
        public const string VIEW_PAGE_CLAIM_TYPE_PROFILE = "VIEW_PROFILE";

        // VIEW CHAT PAGE
        public const string VIEW_PAGE_CLAIM_TYPE_CHAT = "VIEW_CHAT";

        // VIEW EVENTS PAGE
        public const string VIEW_PAGE_CLAIM_TYPE_EVENTS = "VIEW_EVENTS";

        // VIEW SEARCH PAGE
        public const string VIEW_PAGE_CLAIM_TYPE_SEARCH = "VIEW_SEARCH";

        // VIEW RATINGS AND REVIEW PAGE
        public const string VIEW_PAGE_CLAIM_TYPE_RATINGS_REVIEW = "VIEW_RATINGS_REVIEW";

    }
}