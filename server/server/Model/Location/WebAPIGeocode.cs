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
    public class WebAPIGeocode : IGeoCoordinates
    {
        public WebAPIGeocode()
        {

        }

        public string County { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsValid { get; set; }
    }
}