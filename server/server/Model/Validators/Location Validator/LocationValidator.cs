using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using server.Model.Location;
using server.Constants;
using server.Model.Network_Communication;
using System.Threading.Tasks;
using server.Model.Data_Transfer_Objects.Network_Communication_DTO_s;

namespace server.Model.Validators.Location_Validator
{
    public class LocationValidator : AbstractValidator<Address>
    {
        /// <summary>
        /// Geocoordinates from the web api if the location is validated
        /// </summary>
        public WebAPIGeocode ValidatedLocation { get; set; }

        /// <summary>
        /// Validates the location based on business rules
        /// </summary>
        public LocationValidator()
        {
            RuleFor(locationInfo => locationInfo.Street).NotNull();
            RuleFor(locationInfo => locationInfo.Street).MaximumLength(250).WithMessage(LocationConstants.STREET_DOESNT_EXIST_ERROR);

            RuleFor(locationInfo => locationInfo.City).NotNull();
            RuleFor(locationInfo => locationInfo.City).MaximumLength(150).WithMessage(LocationConstants.CITY_DOESNT_EXIST_ERROR);

            RuleFor(locationInfo => locationInfo.State).NotNull();
            RuleFor(locationInfo => locationInfo.State).MaximumLength(150).WithMessage(LocationConstants.STATE_DOESNT_EXIST_ERROR); ;

            RuleFor(locationInfo => locationInfo.ZipCode).NotNull();
            RuleFor(locationInfo => locationInfo.ZipCode).MinimumLength(5).WithMessage(LocationConstants.ZIP_DOESNT_EXIST_ERROR);
            RuleFor(locationInfo => locationInfo.ZipCode).MaximumLength(16).WithMessage(LocationConstants.ZIP_DOESNT_EXIST_ERROR);

            RuleFor(locationInfo => locationInfo.getLocation()).Must(CheckAddress).WithMessage(LocationConstants.COUNTY_NOT_VALID_ERROR);

        }

        /// <summary>
        /// Checks if the address is in the scope of Whatfits by sending a request to Google Maps Web API
        /// </summary>
        /// <param name="address"> location based on users input </param>
        /// <returns> status of the validation of the location </returns>
        public bool CheckAddress(string address)
        {
            var location = address.Replace(' ', '+');
            MapWebAPIComm network = new MapWebAPIComm();
            var requestDTO = new NetworkLocationDTO()
            {
                Location = location
            };
            var test = Task.Run(async () => { return await network.Request(requestDTO); }).Result;

            MapDataAdapter dataMapper = new MapDataAdapter();
            var mappedData = dataMapper.Convert(test.Response);

            if (mappedData.County.Equals("Los Angeles County") || !mappedData.County.Equals("Orange County"))
            {
                ValidatedLocation = mappedData;
                return true;
            }
            return false;
        }
    }
}