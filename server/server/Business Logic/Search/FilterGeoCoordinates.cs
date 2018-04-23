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
    public class FilterGeoCoordinates: ICommand
    {
        public GeoCoordinate UserLocation { get; set; }
        public List<GeoCoordinate> GeoCoordinates { get; set; }
        public int Distance { get; set; }

        public Outcome Execute ()
        {
            var response = new Outcome();
            var coordDictionary = new Dictionary<GeoCoordinate, double>();
            foreach(GeoCoordinate coordinate in GeoCoordinates)
            {
                double calcDistance = UserLocation.GetDistanceTo(coordinate);
                if (calcDistance <= Distance )
                {
                    coordDictionary.Add(coordinate, calcDistance);
                }
            }

            response.Result = coordDictionary;

            return response;
        }
    }
}