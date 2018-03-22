using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Model.Location
{
    public class Geocode: ILocation, IGeoCoordinates
    {
        public Geocode(string address, string city, string state, string zipCode, string county, string latitude, string longitude)
        {
            this.Street = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string getLocation()
        {
            return Street + ", " + City + ", " + State;

        }
    }
}