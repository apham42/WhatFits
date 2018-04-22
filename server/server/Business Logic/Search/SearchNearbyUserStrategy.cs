using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Model.Search;
using server.Interfaces;
using server.Model;
using server.Model.Data_Transfer_Objects.SearchDTO_s;
using server.Constants;
using server.Business_Logic.Validators.Location_Validator;
using server.Model.Location;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Business_Logic.Search
{
    public class SearchNearbyUserStrategy: ICommand
    {
        public SearchDTO Search { get; set; }

        public Outcome Execute () 
        {
            var messages = new List<string>();
            var searchResponse = new SearchResponseDTO();
            var response = new Outcome();

            // Checks if the requested search has a value
            if (Search.Criteria.RequestedSearch == null || Search.Criteria.RequestedSearch.Equals(""))
            {
                searchResponse.IsSuccessful = false;
                messages.Add(LocationConstants.ADDRESS_EMPTY_ERROR);
                searchResponse.Messages = messages;
                response.Result = searchResponse;
                return response;
            }

            // Validates the location that the user inputted 
            var validator = new WebAPILocationValidator()
            {
                RequestedLocation = Search.Criteria.RequestedSearch
            };
            var validatedLocation = (WebAPIGeocode) validator.Execute().Result;
            if (!validatedLocation.IsValid)
            {
                searchResponse.IsSuccessful = false;
                messages.Add(LocationConstants.ADDRESS_NOT_VALID_ERROR);
                searchResponse.Messages = messages;
                response.Result = searchResponse;
                return response;
            }

            // Retrieve all locations from database
            // searchResponse.GeoList = new SearchGateway().RetrieveLocations().LocationResults;
            searchResponse.IsSuccessful = true;
            response.Result = searchResponse;

            return response;
        }
    }
}