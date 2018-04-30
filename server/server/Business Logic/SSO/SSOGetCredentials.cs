using server.Interfaces;
using server.Model;
using server.Model.Data_Transfer_Objects.SSODTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Whatfits.Hash;

namespace server.Business_Logic.SSO
{
    public class SSOGetCredentials : ICommand
    {
        private ClaimsPrincipal incommingPrincipal = (ClaimsPrincipal) HttpContext.Current.User;
        public SSORegistrationResponseDTO ssoregresponse;

        public Outcome Execute()
        {
            Outcome response = new Outcome();

            if (incommingPrincipal == null)
            {
                ssoregresponse.isSuccessful = false;
                ssoregresponse.Messages.Add("No User");
                return response;
            }

            HMAC256 hashing = new HMAC256();

            var salt = hashing.GenerateSalt();
            HashDTO hashDTO = new HashDTO()
            {
                Original = incommingPrincipal.Claims.Where(c => c.Type == "password")
                                                            .Select(c => c.Value).SingleOrDefault() + salt
            };


            ssoregresponse.username = incommingPrincipal.Claims.Where(c => c.Type == "username")
                                                         .Select(c => c.Value).SingleOrDefault();
            ssoregresponse.password = hashing.Hash(hashDTO);
            ssoregresponse.salt = salt;
            ssoregresponse.Messages.Add("Success!");
            ssoregresponse.isSuccessful = true;

            response.Result = ssoregresponse;

            return response;
        }

    }
}