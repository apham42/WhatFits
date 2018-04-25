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

        public SearchGatewayResponseDTO RetrieveUsers(SearchGatewayDTO dto)
        {
            SearchGatewayResponseDTO response = new SearchGatewayResponseDTO();
            List<string> messages = new List<string>();
            try
            {
                // Retrieving users information based on validated Location
                /**
                var results = (from u in db.Users
                              select new SearchResult
                              {
                                User = u.Credential.UserName,
                                SkillLevel = u.SkillLevel,
                                Longitude = u.Location.Longitude,
                                Latitude = u.Location.Latitude
                              }).AsEnumerable()
                              .Where(x => validatedLocations.Contains( x.UserCoordinate = new GeoCoordinate(x.Latitude, x.Longitude)) && x.SkillLevel.Contains(dto.SkillCriteria) && !x.User.Equals(dto.RequestedUser))
                              .ToList();
                 **/
                var results = (from u in db.Users
                               where u.Credential.UserName != dto.RequestedUser
                               select new UserSearch
                               {
                                   User = u.Credential.UserName,
                                   SkillLevel = u.SkillLevel,
                                   Longitude = u.Location.Longitude,
                                   Latitude = u.Location.Latitude
                               }).ToList();
                               /**
                               .Select(x => new UserSearch()
                               {
                                   User = x.UserName,
                                   SkillLevel = x.SkillLevel,
                                   UserCoordinate = new GeoCoordinate(x.Latitude, x.Longitude),
                               })
                                .Where(x => validatedLocations.Contains(x.UserCoordinate) && x.SkillLevel.Contains(dto.SkillCriteria) && !x.User.Equals(dto.RequestedUser))
                                .AsEnumerable();

                results = results.Select(x => { x.Distance = Math.Round(dto.geoCoordinates[x.UserCoordinate], 2); return x; });
                results = results.OrderBy(x => x.Distance).ThenBy(x => x.SkillLevel);
                **/
                if (results.Any())
                {
                    response.Results = results.ToList();
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
