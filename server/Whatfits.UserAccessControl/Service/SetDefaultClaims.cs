using System.Collections.Generic;
using System.Security.Claims;
using Whatfits.UserAccessControl.Constants;

namespace Whatfits.UserAccessControl.Service
{
    public class SetDefaultClaims
    {
        public List<Claim> GetDefaultClaims()
        {
            return new List<Claim>() {
                // WORKOUTLOG CLAIMS
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_ADD, ValueConstant.WORKOUTLOG_CLAIM_VALUE_ADD),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.WORKOUTLOG_CLAIM_VALUE_VIEW),
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_EDIT, ValueConstant.WORKOUTLOG_CLAIM_VALUE_EDIT),
                new Claim(TypeConstant.WORKOUTLOG_CLAIM_TYPE_DELETE, ValueConstant.WORKOUTLOG_CLAIM_VALUE_DELETE),
                
                // SEARCH CLAIMS
                new Claim(TypeConstant.SEARCH_CLAIM_TYPE, ValueConstant.SEARCH_CLAIM_VALUE),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.SEACH_CLAIM_VALUE_VIEW),

                // CHAT CLAIMS
                new Claim(TypeConstant.CHAT_CLAIM_TYPE, ValueConstant.CHAT_CLAIM_VALUE),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.CHAT_CLAIM_VALUE_VIEW),

                // FOLLOWERLIST CLAIMS
                new Claim(TypeConstant.FOLLOW_CLAIM_TYPE, ValueConstant.FOLLOW_CLAIM_VALUE),
                new Claim(TypeConstant.FOLLOWERSLIST_CLAIM_TYPE, ValueConstant.FOLLOWERSLIST_CLAIM_VALUE),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.FOLLOWERSLIST_CLAIM_VALUE_VIEW),

                // RATINGS AND REVIEWS CLAIMS
                new Claim(TypeConstant.RATE_CLAIM_TYPE, ValueConstant.RATE_CLAIM_VALUE),
                new Claim(TypeConstant.REVIEW_CLAIM_TYPE, ValueConstant.REVIEW_CLAIM_VALUE),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.RATINGE_REVIEW_CLAIM_VALUE_VIEW),

                // EVENT CLAIMS
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_ADD, ValueConstant.EVENT_CLAIM_VALUE_ADD),
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_DELETE, ValueConstant.EVENT_CLAIM_VALUE_DELETE),
                new Claim(TypeConstant.EVENT_CLAIM_TYPE_EDIT, ValueConstant.EVENT_CLAIM_VALUE_EDIT),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.EVENT_CLAIM_VALUE_VIEW),

                // PROFILE CLAIMS
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.VIEW_PAGE_CLAIM_VALUE_PROFILE)
                };
        }

        public  List<Claim> GetAdminClaims()
        {
            return new List<Claim>() {
                new Claim(TypeConstant.USER_MANAGMENT_CLAIM_TYPE_CREATE, ValueConstant.USER_MANAGMENT_CLAIM_VALUE_CREATE),
                new Claim(TypeConstant.USER_MANAGMENT_CLAIM_TYPE_UPDATE, ValueConstant.USER_MANAGMENT_CLAIM_VALUE_UPDATE),
                new Claim(TypeConstant.USER_MANAGMENT_CLAIM_TYPE_DELETE, ValueConstant.USER_MANAGMENT_CLAIM_VALUE_DELETE),
                new Claim(TypeConstant.VIEW_PAGE, ValueConstant.USER_MANAGMENT_CLAIM_VALUE_VIEW)
            };
        }
    }
}
