using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Model.Location
{
    /// <summary>
    /// Contains the information that Whatfits need from the Web API.
    /// </summary>
    public class WebAPIGeocode
    {
        public WebAPIGeocode()
        {

        }

        public string County { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public bool IsValid { get; set; }
    }
}