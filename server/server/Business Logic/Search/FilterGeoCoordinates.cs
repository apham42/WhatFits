using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.Models.Models;
using server.Interfaces;
using server.Model;
namespace server.Business_Logic.Search
{
    public class FilterGeoCoordinates: ICommand
    {
        public List<GeoCoordinate> GeoCoordinates { get; set; }
        public int Distance { get; set; }

        public Outcome Execute ()
        {
            var result = new Outcome();


            return result;
        }
    }
}