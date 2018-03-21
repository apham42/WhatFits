using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Address
{
    public class GoogleMapLocation
    {
        public GoogleMapLocation(string address, string city, string state, string zipCode, string county, string latitude, string longitude)
        {
            this.Address = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.County = county;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public string Address { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string County { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
    }
}