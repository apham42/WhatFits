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
    /// <summary>
    /// Searches user based on the search user criteria
    /// </summary>
    public class SearchUserStrategy: ICommand
    {
       public SearchUser SearchUserCriteria { get; set; }

       public Outcome Execute ()
       {
            var result = new Outcome();
            var response = new SearchResponseDTO();
            var messages = new List<string>();

            // Validates the Criteria that the user has entered
            var validator = new ValidateSearchUserCriteria()
            {
                SearchUserCriteria = SearchUserCriteria
            };

            var validatedCriteria = (SearchResponseDTO) validator.Execute().Result;

            // if validator fails, return the result
            if (!validatedCriteria.IsSuccessful)
            {
                result.Result = validatedCriteria;
                return result;
            }
            
            // retrieve users
            var gatewayResponse = new SearchGateway().RetrieveUsers();
            if (!gatewayResponse.IsSuccessful)
            {
                response.IsSuccessful = false;
                response.Messages = gatewayResponse.Messages;
                result.Result = response;
                return result;
            }

            // Gets the user info based on username
            var requestedBy = gatewayResponse.Results.Where(x => x.User == SearchUserCriteria.RequestedBy).FirstOrDefault();
            if (requestedBy == null)
            {
                response.IsSuccessful = false;
                messages.Add(SearchConstants.NO_REQUESTEDBY_ERROR);
                response.Messages = messages;
                result.Result = response;
                return result;
            }

            var requestedUser = gatewayResponse.Results.Where(x => x.User == SearchUserCriteria.RequestedUser).FirstOrDefault();
            if (requestedUser == null)
            {
                response.IsSuccessful = false;
                messages.Add(SearchConstants.NO_USER_ERROR);
                response.Messages = messages;
                result.Result = response;
                return result;
            }

            // Creates Geocoordinates based on the two users location and generates a search result
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