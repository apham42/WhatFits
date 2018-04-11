using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Model.Location
{
    /// <summary>
    /// Contains the user's input address information
    /// </summary>
    public class Address : ILocation
    {
        public Address(string street, string city, string state, string zipCode)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }

        public string getLocation()
        {
            return Street + ", " + City + ", " + State;
        }

    }
}