using server.Business_Logic.Services;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.Models.Models;

namespace server.Controllers
{
    /// <summary>
    /// Provides APIs for Followers list for Clientside
    /// </summary>
    [RoutePrefix("v1/follows")]
    public class FollowsController : ApiController
    {
        Credential requestedUser = new Credential();
        FollowsDTO followsDTO = new FollowsDTO();
        FollowsGateway followsGateway = new FollowsGateway();
        FollowsService followService = new FollowsService();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Users' followers</returns>
        [HttpPost]
        [Route("getfollows")]
        [EnableCors("http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
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
        [Route("addfollows")]
        [EnableCors("http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public HttpResponseMessage Addfollows(string username)
        {
            requestedUser.UserName = username;
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    followService.Add(followsDTO);
                    return new HttpResponseMessage(HttpStatusCode.Accepted);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            }
        }

        /// <summary>
        /// Remove requesteduser from following list
        /// </summary>
        /// <param name="username"></param>
        [HttpPost]
        [Route("deletefollows")]
        [EnableCors("http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "POST")]
        public HttpResponseMessage Deletefollows(string username)
        {
            requestedUser.UserName = username;
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    followService.Remove(followsDTO);
                    return new HttpResponseMessage(HttpStatusCode.Accepted);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True of False</returns>
        [HttpGet]
        [Route("isfollows")]
        [EnableCors("http://localhost:8080 , http://longnlong.com , http://whatfits.social", "*", "GET")]
        public HttpResponseMessage Isfollows(string username)
        {
            requestedUser.UserName = username;
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                if (followsGateway.DoesUserNameExists(requestedUser))
                {
                    followService.Contains(followsDTO);
                    return new HttpResponseMessage(HttpStatusCode.Accepted);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            }
        }
    }
}