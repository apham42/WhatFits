using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using server.Interfaces;
using server.Model;
using Whatfits.DataAccess.Gateways.ContentGateways;
using System.Device.Location;

namespace server.Model.Search
{
    public class SearchResult
    {
        public string User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Skill { get; set; }
        public double Distance { get; set; }
    }
}