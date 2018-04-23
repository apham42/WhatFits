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

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class SearchGateway
    {
        private SearchContext db = new SearchContext();

        public UsernameResponseDTO SearchUser(UsernameDTO dto)
        {
            UsernameResponseDTO response = new UsernameResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                string username = (from x in db.Credentials
                                   where x.UserName == dto.Username
                                   select x.UserName).FirstOrDefault();
                if (dto.Username == username)
                {
                    response.isSuccessful = true;
                    messages.Add("User " + dto.Username + " was found");

                }
                else
                {
                    response.isSuccessful = false;
                    messages.Add(AccountGatewayConstants.USER_DNE_ERROR);
                }
                response.Messages = messages;
            }
            catch (SqlException)
            {
                response.isSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
                response.Messages = messages;
            }
            catch (DataException)
            {
                response.isSuccessful = false;
                messages.Add(ServerConstants.SERVER_ERROR);
                response.Messages = messages;
            }
            return response;
        }

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

        public LocationResponseDTO FilterSearch(SearchGatewayDTO dto)
        {
            LocationResponseDTO response = new LocationResponseDTO();
            List<string> messages = new List<string>();
            var regex = "Long Beach";
            try
            {
                var rx = new Regex(regex);
                var results = (from x in db.Locations
                               select new { x.City, x.Longitude, x.Latitude })
                                                    .AsEnumerable().Where(x => rx.IsMatch(x.City)).Select(x => new GeoCoordinate()
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
    }
}
