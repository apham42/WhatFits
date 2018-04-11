//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Whatfits.DataAccess.DTOs.CoreDTOs;
//using Whatfits.DataAccess.Gateways.CoreGateways;

//namespace Whatfits.UserAccessControl.Service
//{
//    public class UserAccessDatabaseAccess
//    {
//        //gate way for db
//        //private UserAccessControlGateway gateway = new UserAccessControlGateway();
//        // username
//        private string Username = "";
//        //// useraccess dto that contains username and list of claims
//        //private UserAccessDTO dto = null;

//        /// <summary>
//        /// constructor for UserAccessDatabaseAccess
//        /// </summary>
//        /// <param name="username">getting claims of username</param>
//        public UserAccessDatabaseAccess(string username)
//        {
//            //Username
//            Username = username;
//            //dto for useraccess contains username and list of claims
//            //dto = new UserAccessDTO()
//            //{
//            //    UserName = username,
                
//            //};
//        }
        
//        /// <summary>
//        /// Get list of claims
//        /// </summary>
//        /// <returns>list of claims</returns>
//        public List<Claim> GetClaims()
//        {
//            ////get claims of of dto
//            //dto = gateway.GetUserClaims(dto);
//            //// return list of claims
//            //return dto.UserClaims;

//            return new List<Claim>()
//            {
//                new Claim("WORKOUT_ADD", "ADD"),
//                new Claim("EVENT_ADD", "ADD"),
//                new Claim("FRIENDS", "Friend")
//            };

//        }
//    }
//}
