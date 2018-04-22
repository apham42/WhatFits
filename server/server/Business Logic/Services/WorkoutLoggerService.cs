using server.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Services
{
    public class WorkoutLoggerService
    {

        public bool Create(WorkoutLogDTO w)
        {
            var gateway = new WorkoutLogGateway();
            return gateway.CreateWorkoutLog(w);
        }

        //Returns Review objects to front end, ReviewMessage, Rating, and Datetime
        public IEnumerable<ReviewDetailDTO> GetUserReview(string Username)
        {
            var gateway = new ReviewsGateway();
            return gateway.GetUserReviewDetails(Username);
        }
    }
}