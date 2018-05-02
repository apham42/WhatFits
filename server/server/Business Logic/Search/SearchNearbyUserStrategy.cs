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
using System.Device.Location;
using Whatfits.DataAccess.Constants;

namespace server.Business_Logic.Search
{
    /// <summary>
    /// Searches nearby users based on the criteria inside the SearchDTO
    /// </summary>
    public class SearchNearbyUserStrategy: ICommand
    {
        public SearchCriteria Search { get; set; }

        /// <summary>
        /// Executes the strategy of searching nearby users based on an address
        /// </summary>
        /// <returns> The users with their username, skill, workout type, and distance that fits the search criteria</returns>
        public Outcome Execute () 
        {
            var searchResponse = new SearchResponseDTO();
            var response = new Outcome();

            // Validates the Criteria that the user has entered
            var criteriaValidator = new ValidateSearchNearbyCriteria()
            {
                SearchNearbyCriteria = Search
            };

            var validatedCriteria = (SearchResponseDTO) criteriaValidator.Execute().Result;

            // if validator fails, return the result
            if (!validatedCriteria.IsSuccessful)
            {
                response.Result = validatedCriteria;
                return response;
            }

            // Validates the location that the user inputted 
            var locationValidator = new WebAPILocationValidator()
            {
                RequestedLocation = Search.RequestedSearch
            };
            var validatedLocation = (WebAPIGeocode)locationValidator.Execute().Result;
            if (!validatedLocation.IsValid)
            {
                response.Result = Error(LocationConstants.ADDRESS_NOT_VALID_ERROR);
                return response;
            }

            var gateway = new SearchGateway();

            // Retrieve all locations from database
            var locationResponseDTO = gateway.RetrieveLocations();
            if (!locationResponseDTO.IsSuccessful)
            {
                response.Result = Error(locationResponseDTO.Messages.First());
            }

            var locations = locationResponseDTO.LocationResults;
            if (!locations.Any())
            {
                response.Result = Error(LocationGatewayConstants.NO_LOCATION_FOUND_ERROR);
                return response;
            }

            // Filtering the locations based on the distance
            var filterLocation = new FilterGeoCoordinates()
            {
                UserLocation = new GeoCoordinate(validatedLocation.Latitude, validatedLocation.Longitude),
                GeoCoordinates = locations,
                Distance = Search.Distance.Value,
            };
            var filteredGeocoordinates = (Dictionary<GeoCoordinate, double>) filterLocation.Execute().Result;
            if (!filteredGeocoordinates.Any())
            {
                response.Result = Error(SearchConstants.NO_NEARBY_USERS_ERROR);
                return response;
            }

            // Generates the search results
            var filterSearch = new GenerateSearchResults()
            {
                Criteria = Search,
                ValidatedLocations = filteredGeocoordinates
            };
            response.Result =  (SearchResponseDTO) filterSearch.Execute().Result;

            return response;
        }


        public SearchResponseDTO Error(string message)
        {
            var response = new SearchResponseDTO()
            {
                IsSuccessful = false,
                Messages = new List<string>()
            };

            response.Messages.Add(message);
            return response;
        }
    }
}