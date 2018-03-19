using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.UserAccessControl.Constants;

namespace Whatfits.UserAccessControl.Service
{
    public static class SetDefaultClaims
    {
        public static List<Claim> GetDefaultClaims()
        {
            return new List<Claim>() {
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_ADD, ValueConstant.WORKOUTLOG_CLAIM_VALUE_ADD),
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_VIEW, ValueConstant.WORKOUTLOG_CLAIM_VALUE_VIEW),
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_EDIT, ValueConstant.WORKOUTLOG_CLAIM_VALUE_EDIT),
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_DELETE, ValueConstant.WORKOUTLOG_CLAIM_VALUE_DELETE),
                new Claim(TypeConstant.SEARCH_CLAIM_TYPE, ValueConstant.SEARCH_CLAIM_VALUE),
                new Claim(TypeConstant.CHAT_CLAIM_TYPE, ValueConstant.CHAT_CLAIM_VALUE),
                new Claim(TypeConstant.FOLLOW_CLAIM_TYPE, ValueConstant.FOLLOW_CLAIM_VALUE),
                new Claim(TypeConstant.FOLLOWERSLIST_CLAIM_TYPE, ValueConstant.FOLLOWERSLIST_CLAIM_VALUE),
                new Claim(TypeConstant.RATE_CLAIM_TYPE, ValueConstant.RATE_CLAIM_VALUE),
                new Claim(TypeConstant.REVIEW_CLAIM_TYPE, ValueConstant.REVIEW_CLAIM_VALUE),
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_ADD, ValueConstant.EVENT_CLAIM_VALUE_ADD),
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_DELETE, ValueConstant.EVENT_CLAIM_VALUE_DELETE),
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_EDIT, ValueConstant.EVENT_CLAIM_VALUE_EDIT),
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_VIEW, ValueConstant.EVENT_CLAIM_VALUE_VIEW)
                };
        }
    }
}
