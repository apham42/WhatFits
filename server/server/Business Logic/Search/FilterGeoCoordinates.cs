using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.Models.Models;
using server.Interfaces;
using server.Model;
using System.Device.Location;

namespace server.Business_Logic.Search
{
    /// <summary>
    /// Filters the geocoordinates based on the distance provided.
    /// FilterGeocoordinates implements the Command pattern.
    /// </summary>
    public class FilterGeoCoordinates: ICommand
    {
        public GeoCoordinate UserLocation { get; set; }
        public List<GeoCoordinate> GeoCoordinates { get; set; }
        public int Distance { get; set; }

        /// <summary>
        /// Filters the Geocoordinates based on the distance and converts the distance to  miles.
        /// </summary>
        /// <returns> an object that contains the geocoordinates in the radius </returns>
        public Outcome Execute ()
        {
            var response = new Outcome();
            var coordDictionary = new Dictionary<GeoCoordinate, double>();
            foreach(GeoCoordinate coordinate in GeoCoordinates)
            {
                double calcDistance = (UserLocation.GetDistanceTo(coordinate) / 1609.344);
                if (Distance >= calcDistance)
                {
                    coordDictionary.Add(coordinate, calcDistance);
                }
            }

            response.Result = coordDictionary;

            return response;
        }
    }
}