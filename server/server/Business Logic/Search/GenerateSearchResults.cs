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
    /// <summary>
    /// Generates the results based on the validated locations and the search criteria
    /// </summary>
    public class GenerateSearchResults: ICommand
    {
        public Dictionary<GeoCoordinate, double> ValidatedLocations { get; set; }
        public SearchCriteria Criteria { get; set; }

        /// <summary>
        /// Uses the Command Pattern and executes the generate search result logic
        /// </summary>
        /// <returns> an outcome object containing the search results</returns>
        public Outcome Execute()
        {
            var result = new Outcome();
            var response = new SearchResponseDTO();
            var messages = new List<string>();

            var gateway = new SearchGateway();

            // Gets user info
            var gatewayResponse = gateway.RetrieveUsers();
            if (!gatewayResponse.IsSuccessful)
            {
                response.IsSuccessful = false;
                response.Messages = gatewayResponse.Messages;
                result.Result = response;
            }

            // Filters the user search based on the distance of the coordinates
            var filteredResults = gatewayResponse.Results.Select(x => new
            {
                x.User,
                x.FirstName,
                x.LastName,
                x.SkillLevel,
                UserCoordinate = new GeoCoordinate(x.Latitude, x.Longitude),
            }).Where(x => ValidatedLocations.ContainsKey(x.UserCoordinate) && x.SkillLevel.Contains(Criteria.Skill) && x.User != Criteria.RequestedUser);

            // Map the filteredResults to a list of SearchResult objects
            var searchResults = filteredResults.Select(x => new SearchResult()
            {
                User = x.User,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Skill = x.SkillLevel,
                Distance = Math.Round(ValidatedLocations[x.UserCoordinate], 2)
            } ).AsEnumerable();
            searchResults = searchResults.OrderBy(x => x.Distance);

            // Changes the response data based if filtered data has any users in it
            if(!searchResults.Any())
            {
                response.IsSuccessful = false;
                messages.Add(SearchConstants.NO_NEARBY_USERS_ERROR);
                response.Messages = messages;
            }
            else
            {
                response.IsSuccessful = true;
                messages.Add(SearchConstants.USERS_FOUND_ERROR);
                response.Messages = messages;
                response.SearchResults = searchResults.ToList();
            }

            result.Result = response;
            return result;
        }
    }
}