using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.SSODTOs;
using Whatfits.Models.Context.Core;
using Whatfits.Models.Interfaces;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.SSOGateways
{
    public class SSORegistrationGateway
    {
        private AccountContext db = new AccountContext();

        public SSORegDTO SSORegistration(SSORegDTO dto)
        {
            var checkCredential = (from u in db.Credentials
                                    where u.UserName == dto.username
                                    select u).FirstOrDefault();
            var getLocation = (from u in db.Locations
                               where u.Address == "NULL" && 
                               u.City == "NULL" && 
                               u.State == "NULL" && 
                               u.Zipcode == "NULL"
                               select u).FirstOrDefault();

            SSORegDTO response = new SSORegDTO();
            response.Messages = new List<string>();
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try {
                    if (getLocation == null)
                    {
                        Location location = new Location()
                        {
                            Address = "NULL",
                            City = "NULL",
                            State = "NULL",
                            Zipcode = "NULL",
                            Latitude = 0.0,
                            Longitude = 0.0
                        };
                        db.Locations.Add(location);
                        db.SaveChanges();
                    }
                    if (checkCredential == null)
                    {
                        var locationID = (from u in db.Locations
                                           where u.Address == "NULL" && 
                                           u.City == "NULL" && 
                                           u.State == "NULL" && 
                                           u.Zipcode == "NULL"
                                          select u).FirstOrDefault();
                        Credential cred = new Credential()
                        {
                            UserName = dto.username,
                            Password = dto.password
                        };
                        db.Credentials.Add(cred);
                        db.SaveChanges();

                        Salt salt = new Salt()
                        {
                            UserID = cred.UserID,
                            SaltValue = dto.salt,
                            Credential = cred
                        };
                        db.Salts.Add(salt);
                        db.SaveChanges();

                        UserProfile type = new UserProfile()
                        {
                            UserID = cred.UserID,
                            LocationID = locationID.LocationID,
                            Type = "SSO"
                        };

                        db.UserProfiles.Add(type);
                        db.SaveChanges();

                        dbTransaction.Commit();
                        response.Messages.Add("Success!");
                        response.isSuccessful = true;
                        return response;
                    }

                    dbTransaction.Rollback();
                    response.Messages.Add("User Already Exist");
                    response.isSuccessful = false;
                    return response;
                }catch(MulticastNotSupportedException)
                {
                    dbTransaction.Rollback();
                    response.Messages.Add("Failed to Exist");
                    response.isSuccessful = false;
                    return response;
                }
            }
        }
    }
}
