using server.Business_Logic.Services;
using server.Controllers.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.Models.Models;
using Whatfits.UserAccessControl.Constants;
using Whatfits.UserAccessControl.Controller;

namespace server.Controllers
{
    /// <summary>
    /// Provides APIs for Followers list for Clientside
    /// </summary>
    [RoutePrefix("v1/Follows")]
    public class FollowsController : ApiController
    {
        Credential requestedUser = new Credential();
        Credential followUser = new Credential();
        FollowsDTO followsDTO = new FollowsDTO();
        FollowsGateway followsGateway = new FollowsGateway();
        FollowsService followService = new FollowsService();

        /// <summary>
        /// Provides local inivial value
        /// </summary>
        public List<Int16> Getiv()
        {
            // Read initial value from file
            try
            {
                var dir = HostingEnvironment.MapPath("~\\lifeisgood.txt");
                var filecontent = File.ReadAllText(dir);
                var iv = filecontent.Split(',').Select(Int16.Parse).ToList();
                return iv;
            } catch(Exception)
            {
                // if Read file fail
                List<Int16> iv = new List<Int16> { 21, 2, 3, 14, 65, 6, 17, 8, 91, 10, 11, 12, 23, 14, 45, 16 };
                return iv;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Users' follows</returns>
        [HttpPost]
        //[AuthorizePrincipal(type = TypeConstant.FOLLOW_CLAIM_TYPE, value = ValueConstant.FOLLOW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.headers, CORS.origins, "POST")]
        public IHttpActionResult Getfollows([FromBody]UsernameDTO userDTO)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                requestedUser.UserName = userDTO.Username;
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    return Ok(followService.GetEnumerator(userDTO.Username));
                }
                else
                {
                    return Content(HttpStatusCode.NotAcceptable, new { });
                }
            }
            else
            {
                return Content(HttpStatusCode.MethodNotAllowed,new { });
            }
        }

        /// <summary>
        /// Add requested user to following list
        /// </summary>
        /// <param name="username"></param>
        [HttpPost]
        //[AuthorizePrincipal(type = TypeConstant.FOLLOW_CLAIM_TYPE, value = ValueConstant.FOLLOW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.headers, CORS.origins, "POST")]
        public IHttpActionResult Addfollows([FromBody]UsernameDTO userDTO)
        {
            string[] Users = userDTO.Username.Split(' ');
            requestedUser.UserName = Users[0];
            var wantoFollo = Users[1];

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    return Ok(followService.Add(requestedUser.UserName, wantoFollo));
                }
                else
                {
                    return Content(HttpStatusCode.NotAcceptable, new { });
                }
            }
            else
            {
                return Content(HttpStatusCode.MethodNotAllowed,new { });
            }
        }

        /// <summary>
        /// Remove requesteduser from following list
        /// </summary>
        /// <param name="username"></param>
        [HttpPost]
        //[AuthorizePrincipal(type = TypeConstant.FOLLOW_CLAIM_TYPE, value = ValueConstant.FOLLOW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.headers, CORS.origins, "POST")]
        public IHttpActionResult Deletefollows([FromBody]UsernameDTO userDTO)
        {
            string[] Users = userDTO.Username.Split(' ');
            requestedUser.UserName = Users[0];
            var wantoDelete = Users[1];

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    return Ok(followService.Remove(requestedUser.UserName, wantoDelete));
                }
                else
                {
                    return Content(HttpStatusCode.NotAcceptable, new { });
                }
            }
            else
            {
                return Content(HttpStatusCode.MethodNotAllowed, new { });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True of False</returns>
        [HttpPost]
        //[AuthorizePrincipal(type = TypeConstant.FOLLOW_CLAIM_TYPE, value = ValueConstant.FOLLOW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.headers, CORS.origins, "POST")]
        public IHttpActionResult Isfollows([FromBody]UsernameDTO userDTO)
        {
            string[] Users = userDTO.Username.Split(' ');
            requestedUser.UserName = Users[0];
            var wantoDelete = Users[1];

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    return Ok(followService.Contains(requestedUser.UserName, wantoDelete));
                }
                else
                {
                    return Content(HttpStatusCode.NotAcceptable, new { });
                }
            }
            else
            {
                return Content(HttpStatusCode.MethodNotAllowed, new { });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True of False</returns>
        [HttpPost]
        //[AuthorizePrincipal(type = TypeConstant.FOLLOW_CLAIM_TYPE, value = ValueConstant.FOLLOW_CLAIM_VALUE)]
        [EnableCors(origins: CORS.origins, headers: CORS.headers, "POST")]
        public IHttpActionResult GetInitialvalue([FromBody]UsernameDTO userDTO)
        {
            requestedUser.UserName = userDTO.Username;
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    return Ok(Getiv());
                }
                else
                {
                    return Content(HttpStatusCode.NotAcceptable, new { });
                }
            }
            else
            {
                return Content(HttpStatusCode.MethodNotAllowed, new { });
            }
        }
    }
}