using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using Newtonsoft.Json.Linq;
using server.Model.Location;

namespace server.Model.Network_Communication
{
    /// <summary>
    /// Maps the data recieved from the Map Web API
    /// </summary>
    public class MapDataAdapter : IDataAdapter<WebAPIGeocode, string>
    {
        public MapDataAdapter()
        {

        }

        /// <summary>
        /// Converts the string content of the data received from the Web API
        /// </summary>
        /// <param name="apiData"></param>
        /// <returns>A mapped object that contains the information we need from the web api data</returns>
        public WebAPIGeocode Convert(string apiData)
        {
            var data = JObject.Parse(apiData);
            var mappedData = new WebAPIGeocode();
            bool foundStreet = false;

            // Returns if the response of the api failed 
            if (!data["status"].ToString().Equals("OK"))
            {
                mappedData.IsValid = false;
                return mappedData;
            }

            // Finds the county of the location in the web api data
            JArray convertedData = (JArray)data["results"][0]["address_components"];
            int addressComponentsLength = convertedData.Count;
            for (int i = 0; i < convertedData.Count; i++)
            {
                // Finding the County information in the JSON data from the web api
                if (data["results"][0]["address_components"][i]["types"][0].ToString().Equals("administrative_area_level_2"))
                {
                    mappedData.County = data["results"][0]["address_components"][i]["long_name"].ToString();
                }
                else if (!foundStreet & data["results"][0]["address_components"][i]["types"][0].ToString().Equals("street_number"))
                {
                    mappedData.Street = data["results"][0]["address_components"][i]["long_name"].ToString();
                    foundStreet = true;
                }
                else if (foundStreet & data["results"][0]["address_components"][i]["types"][0].ToString().Equals("route"))
                {
                    mappedData.Street += " " + data["results"][0]["address_components"][i]["long_name"].ToString();
                }
                else if (data["results"][0]["address_components"][i]["types"][0].ToString().Equals("locality"))
                {
                    mappedData.City = data["results"][0]["address_components"][i]["long_name"].ToString();
                }
                else if (data["results"][0]["address_components"][i]["types"][0].ToString().Equals("administrative_area_level_1"))
                {
                    mappedData.State = data["results"][0]["address_components"][i]["long_name"].ToString();
                }
                else if (data["results"][0]["address_components"][i]["types"][0].ToString().Equals("postal_code"))
                {
                    mappedData.ZipCode = data["results"][0]["address_components"][i]["long_name"].ToString();
                }
            }
            // If it was not found, return false
            if (mappedData.County == null)
            {
                mappedData.IsValid = false;
                return mappedData;
            }

            // Gets the latitude and longitude from the web api data
            mappedData.Latitude = Double.Parse(data["results"][0]["geometry"]["location"]["lat"].ToString());
            mappedData.Longitude = Double.Parse(data["results"][0]["geometry"]["location"]["lng"].ToString());
            mappedData.IsValid = true;
            return mappedData;
        }
    }
}