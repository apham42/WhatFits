using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using server.Interfaces;
using server.Model;
using Whatfits.DataAccess.Gateways.ContentGateways;
using server.Model.Data_Transfer_Objects.SearchDTO_s;
using server.Model.Search;
using server.Constants;
using System.Device.Location;

namespace server.Business_Logic.Search
{
    public class SearchUserStrategy: ICommand
    {
       public SearchUser SearchUserCriteria { get; set; }

       public Outcome Execute ()
       {
            var result = new Outcome();
            var response = new SearchResponseDTO();
            var messages = new List<string>();

            var gatewayResponse = new SearchGateway().RetrieveUsers();
            if (!gatewayResponse.IsSuccessful)
            {
                response.IsSuccessful = false;
                response.Messages = gatewayResponse.Messages;
                result.Result = response;
                return result;
            }

            var requestedBy = gatewayResponse.Results.Where(x => x.User == SearchUserCriteria.RequestedBy).FirstOrDefault();

            var requestedUser = gatewayResponse.Results.Where(x => x.User == SearchUserCriteria.RequestedUser).FirstOrDefault();
            if (requestedUser == null)
            {
                response.IsSuccessful = false;
                messages.Add(SearchConstants.NO_USER_ERROR);
                response.Messages = messages;
                result.Result = response;
                return result;
            }

            var requestedByCoord = new GeoCoordinate(requestedBy.Latitude, requestedBy.Longitude);
            var requestedUserCoord = new GeoCoordinate(requestedUser.Latitude, requestedUser.Longitude);

            var userResult = new SearchResult()
            {
                User = requestedUser.User,
                FirstName = requestedUser.FirstName,
                LastName = requestedUser.LastName,
                Skill = requestedUser.SkillLevel,
                Distance = Math.Round(((requestedUserCoord.GetDistanceTo(requestedByCoord)) / 1609.344), 2)
            };

            response.IsSuccessful = true;
            response.SearchResults = new List<SearchResult>();
            response.SearchResults.Add(userResult);
            messages.Add(SearchConstants.USER_FOUND);
            response.Messages = messages;
            result.Result = response;

            return result;
       }

    }
}