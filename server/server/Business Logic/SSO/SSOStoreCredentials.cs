using server.Interfaces;
using server.Model;
using server.Model.Data_Transfer_Objects.SSODTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.SSODTOs;
using Whatfits.DataAccess.Gateways.SSOGateways;

namespace server.Business_Logic.SSO
{
    public class SSOStoreCredentials : ICommand
    {
        public SSORegistrationResponseDTO incommingCredentials;

        public Outcome Execute()
        {
            Outcome response = new Outcome();

            SSORegistrationResponseDTO dto = new SSORegistrationResponseDTO();
            dto.Messages = new List<string>();

            SSORegDTO gatewayDTO = new SSORegDTO()
            {
                username = incommingCredentials.username,
                password = incommingCredentials.password,
                salt = incommingCredentials.salt
            };

            SSORegistrationGateway gateway = new SSORegistrationGateway();
            var gatewayResponse = gateway.SSORegistration(gatewayDTO);

            if(gatewayResponse.isSuccessful == false)
            {
                dto.isSuccessful = false;
                dto.Messages.Add("Faild to add User");
                response.Result = dto;
                return response;
            }

            dto.isSuccessful = true;
            dto.password = "";
            dto.username = "";
            dto.Messages.Add("Success");
            response.Result = dto;
            return response;
        }
    }
}