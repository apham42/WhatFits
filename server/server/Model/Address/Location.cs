using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Address
{
    public class Location
    {
        public Location(string address, string city, string state, string zipCode)
        {
            this.Address = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }

        public string Address { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }

        public string getFullAddress()
        {
            return Address + ", " + City + ", " + State + " " + ZipCode;
        }

    }
}