using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using server.Model.Data_Transfer_Objects;


namespace server.Model.Network_Communication
{
    public class GoogleMapComm
    {
        public string result {get; set;}
        public GoogleMapComm()
        {

        }
        public async Task<string> Request(string address)
        {
            string mapWebAPI = ConfigurationManager.AppSettings["mapURL"];
            string mapWebKey = ConfigurationManager.AppSettings["mapKey"];
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(@"https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyC2S7VIW4VHNZ1h0qHlBIo4QhbpIAkGgus");
                return response;
            }
        }

        public async void test ()
        {
            result = await Request("1600 + Amphitheatre + Parkway, +Mountain + View, +CA");
        }
    }
}