﻿using server.Constants;
using server.Data_Transfer_Objects.ReviewDTO_s;
using server.Model.Data_Transfer_Objects.ReviewDTO_s;
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
    public class ReviewService
    {
        public bool ValidateReview(string message, ReviewDTO response)
        {
            if (message.Length < 1)
            {
                response.message = AccountConstants.PASSWORD_SHORT_ERROR;
                response.status = false;
                return false;
            }

            if (message.Length > 256)
            {
                response.message = AccountConstants.PASSWORD_LONG_ERROR;
                response.status = false;
                return false;
            }

            if (!ValidateCharacters(message))
            {
                response.message = AccountConstants.PASSWORD_INVALID_CHARACTERS_ERROR;
                response.status = false;
                return false;
            }
            response.status = true;
            return true;
        }
        public bool ValidateCharacters(string credential)
        {
            var rgxCheck = new Regex(AccountConstants.CREDCHARACTERS);
            if (rgxCheck.IsMatch(credential))
            {
                return true;
            }
            return false;
        }

        public bool Create(ReviewsDTO rev)
        {
            var gateway = new ReviewsGateway();
            return gateway.AddReview(rev);
        }

        public List<string> GetUserReview(string Username)
        {
            var gateway = new ReviewsGateway();
            return gateway.GetReview(Username);
        }
    }
}