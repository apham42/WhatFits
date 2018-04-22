using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using server.Model;
using server.Model.Data_Transfer_Objects.Network_Communication_DTO_s;
using server.Model.Network_Communication;
using System.Threading.Tasks;
using server.Model.Location;

namespace server.Business_Logic.Validators.Location_Validator
{
    public class WebAPILocationValidator: ICommand
    {
        public string RequestedLocation { get; set; }
        public WebAPIGeocode ValidatedLocation { get; set; }

        public Outcome Execute() 
        {
            MapWebAPIComm network = new MapWebAPIComm();
            var requestDTO = new NetworkLocationDTO()
            {
                Location = RequestedLocation
            };

            // Waits for the request to finish
            var test = Task.Run(async () => { return await network.Request(requestDTO); }).Result;

            // Converts the data from the web api
            MapDataAdapter dataMapper = new MapDataAdapter();
            var mappedData = dataMapper.Convert(test.Response);
            ValidatedLocation = mappedData;

            // Validating County based on the scope 
            if (ValidatedLocation.County != null && (ValidatedLocation.County.Equals("Los Angeles County") || ValidatedLocation.County.Equals("Orange County")))
            {
                ValidatedLocation.IsValid = true;
            }
            else
            {
                ValidatedLocation.IsValid = false;
            }

            return new Outcome()
            {
                Result = ValidatedLocation
            };
        }
    }
}