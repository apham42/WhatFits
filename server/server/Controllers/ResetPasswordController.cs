using server.Business_Logic.Services;
using server.Model.Account;
using server.Model.Data_Transfer_Objects.AccountDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DTOs.CoreDTOs;
using Whatfits.DataAccess.Gateways.CoreGateways;

namespace server.Controllers
{
    // TODO: @AaronPham Controller not done
    [RoutePrefix("v1/ResetPassword")]
    public class ResetPasswordController : ApiController
    {
        private ResetPasswordService service = new ResetPasswordService();

        /// <summary>
        /// get questions
        /// </summary>
        /// <param name="userCredentials">username</param>
        /// <returns>dictonary of questions</returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult GetQuestions([FromBody] UserCredential userCredentials)
        {
            ResetPasswordResponseDTO response = service.GetQuestions(userCredentials);
            response.Messages = new List<string>();
            if (response.isSuccessful == false)
            {
                response.Messages.Add("User not found");
                return Content(HttpStatusCode.NotFound, response.Messages);
            }

            response.Messages.Add("Success!");
            return Ok(response);
        }

        /// <summary>
        /// get answers
        /// </summary>
        /// <param name="userCredentials">username</param>
        /// <param name="incommingAnswers">answers from user</param>
        /// <returns>if user successfully answers questions return OK else unauthorized</returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult GetAnswers([FromBody] IncommingAnswersDTO incommingAnswers)
        {
            ResetPasswordResponseDTO response = service.CheckAnswers(incommingAnswers.resetPasswordResponseDTO, incommingAnswers.userCredential);
            response.Messages = new List<string>();

            if(response.isSuccessful == false)
            {
                response.Messages.Add("Incorrect Password");
                return Content(HttpStatusCode.Unauthorized, response);
            }
            
            response.Messages.Add("Success!");
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCredentials"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080 , http://localhost:8081 , http://longnlong.com , http://whatfits.social", headers: "*", methods: "POST")]
        [AllowAnonymous]
        public IHttpActionResult SetPassword([FromBody] UserCredential usernewCredentials)
        {
            ResetPasswordResponseDTO response = service.ReplaceOldPassword(usernewCredentials);
            response.Messages = new List<string>();

            if (response.isSuccessful == false)
            {
                response.Messages.Add("Failed to replace Password");
                return Content(HttpStatusCode.NotFound, response);
            }

            response.Messages.Add("Success!");
            return Ok(response);
        }
    }
}
