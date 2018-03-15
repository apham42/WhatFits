using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Location
{
    public class Location
    {
        public Location(string address, string city, string zip, string state)
        {
            this.Address = address;
            this.City = city;
            this.ZipCode = zip;
            this.State = state;
        }

        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }

        public string getFullAddress()
        {
            return Address + ", " + City + ", " + State + " " + ZipCode;
        }

    }
}