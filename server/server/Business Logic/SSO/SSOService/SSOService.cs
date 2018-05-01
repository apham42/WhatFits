using server.Model.Data_Transfer_Objects.SSODTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace server.Business_Logic.SSO.SSOService
{
    public class SSOService
    {
        public SSOService()
        {

        }

        public SSORegistrationResponseDTO SSORegistrationService()
        {
            SSORegistrationResponseDTO response = new SSORegistrationResponseDTO();
            response.Messages = new List<string>();

            SSOGetCredentials getSSOCredentials = new SSOGetCredentials()
            {
                ssoregresponse = response
            };

            var creds = (SSORegistrationResponseDTO)getSSOCredentials.Execute().Result;

            if(creds.isSuccessful == false || 
                string.IsNullOrEmpty(creds.username) || 
                string.IsNullOrEmpty(creds.password))
            {
                return creds;
            }

            SSOStoreCredentials addUser = new SSOStoreCredentials()
            {
                incommingCredentials = creds
            };

            var useradded = (SSORegistrationResponseDTO)addUser.Execute().Result;

            if(useradded.isSuccessful == false)
            {
                response.isSuccessful = false;
                response.Messages.Add("Failed");
                return response;
            }

            response.isSuccessful = true;
            response.Messages.Add("Success!");
            
            return response;
        }
    }
}