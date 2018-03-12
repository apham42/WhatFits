using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Whatfits.DataAccess;
using Whatfits.Models;
using Whatfits.Gateways;
using Whatfits.Models.Models;
using Whatfits.Models.Context.Content;


//need a data access object for reviews
namespace server.Controllers
{
    public class ReviewController : ApiController
    {
        //gets list of reviews from database
        //Need to alter web config files and etc, refer to sql server in kudvenkat
        public IEnumerable<Review> Get()
        {
            using (ReviewsContext entites = new ReviewsContext())
            {
                return entities.Reviews.ToList();
            }
        }

        //adds a review into the sql server
        //refer to post method in asp.net kudvenkat
        public HttpResponseMessage Post([FromBody] Review review)
        {
            try
            {
                using (ReviewDBEntities entities = new ReviewDBEntities())
                {
                    entities.Reviews.Add(review);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, review);
                    message.Headers.Location = new Uri(Request.RequestUri + review.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}