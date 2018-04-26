using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using server.Model;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using System.Device.Location;
using server.Model.Data_Transfer_Objects.SearchDTO_s;
using server.Model.Search;
using server.Constants;

namespace server.Business_Logic.Search
{
    public class FilterSearchResults: ICommand
    {
        public Dictionary<GeoCoordinate, double> ValidatedLocations { get; set; }
        public SearchCriteria Criteria { get; set; }
        public string User { get; set; }

        public Outcome Execute()
        {
            var result = new Outcome();
            var response = new SearchResponseDTO();
            var messages = new List<string>();

            var gateway = new SearchGateway();
            var gatewayDTO = new SearchGatewayDTO()
            {
                RequestedUser = User
            };

            // Gets user info
            var gatewayResponse = gateway.RetrieveUsers(gatewayDTO);
            if (!gatewayResponse.IsSuccessful)
            {
                response.IsSuccessful = false;
                response.Messages = gatewayResponse.Messages;
                result.Result = response;
            }

            // Filters the user search based on the distance of the coordinates
            var filteredResults = gatewayResponse.Results.Select(x => new SearchResult()
            {
                User = x.User,
                Skill = x.SkillLevel,
                UserCoordinate = new GeoCoordinate(x.Latitude, x.Longitude),
            }).Where(x => ValidatedLocations.ContainsKey(x.UserCoordinate) && x.Skill.Contains(Criteria.Skill));

            filteredResults = filteredResults.Select(x => { x.Distance = Math.Round(ValidatedLocations[x.UserCoordinate], 2); return x; });
            filteredResults = filteredResults.OrderBy(x => x.Distance);

            // Changes the response data based if filtered data has any users in it
            if(!filteredResults.Any())
            {
                response.IsSuccessful = false;
                messages.Add(SearchConstants.NO_USERS_ERROR);
                response.Messages = messages;
            }
            else
            {
                response.IsSuccessful = true;
                messages.Add(SearchConstants.USERS_FOUND_ERROR);
                response.Messages = messages;
                response.SearchResults = filteredResults.ToList();
            }

            result.Result = response;
            return result;
        }
    }
}