using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Whatfits.Models.Context.Content;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using System.Data.SqlClient;
using System.Data;
using Whatfits.DataAccess.Constants;
using Whatfits.Models.Models;
using System.Device.Location;
using Whatfits.DataAccess.DTOs;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class SearchGateway
    {
        private SearchContext db = new SearchContext();

        public LocationResponseDTO RetrieveLocations()
        {
            LocationResponseDTO response = new LocationResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                var results = (from x in db.Locations
                                                    select new { x.City, x.Longitude, x.Latitude })
                                                    .AsEnumerable().Select(x => new GeoCoordinate() 
                    { 
                        Longitude = x.Longitude,
                        Latitude = x.Latitude 
                    }).ToList();

                if (results.Any())
                {
                    response.LocationResults = results;
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    messages.Add(LocationGatewayConstants.NO_LOCATION_FOUND_ERROR);
                }
            }
            catch (SqlException)
            {
                response.IsSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
            }
            catch (DataException)
            {
                response.IsSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
            }

            response.Messages = messages;
            return response;
        }

        public SearchGatewayResponseDTO RetrieveUsers()
        {
            SearchGatewayResponseDTO response = new SearchGatewayResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                var results = (from u in db.Users
                               select new UserSearch
                               {
                                   User = u.Credential.UserName,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   SkillLevel = u.SkillLevel,
                                   Longitude = u.Location.Longitude,
                                   Latitude = u.Location.Latitude
                               }).ToList();

                if (results.Any())
                {
                    response.Results = results.ToList();
                    messages.Add(SearchGatewayConstants.USERS_FOUND);
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                    messages.Add(SearchGatewayConstants.NO_USERS);
                }
            }
            catch (SqlException)
            {
                response.IsSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
            }
            catch (DataException)
            {
                response.IsSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
            }

            response.Messages = messages;
            return response;
        }
    }
}
