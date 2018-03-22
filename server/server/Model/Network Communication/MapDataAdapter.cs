using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;
using Newtonsoft.Json.Linq;
using server.Model.Location;

namespace server.Model.Network_Communication
{
    public class MapDataAdapter: IDataAdapter<WebAPIGeocode, string>
    {
        public MapDataAdapter()
        {

        }

        public WebAPIGeocode Convert(string request)
        {
            var data = JObject.Parse(request);
            var mappedData = new WebAPIGeocode();
            if (!data["status"].ToString().Equals("OK"))
            {
                mappedData.IsValid = false;
                return mappedData;
            }

            JArray convertedData = (JArray)data["results"][0]["address_components"];
            int addressComponentsLength = convertedData.Count;
            for (int i = 0; i < convertedData.Count; i++)
            {
                if (data["results"][0]["address_components"][i]["types"][0].ToString().Equals("administrative_area_level_2"))
                {
                    mappedData.County = data["results"][0]["address_components"][i]["long_name"].ToString();
                }
            }
            if (mappedData.County == null )
            {
                mappedData.IsValid = false;
                return mappedData;
            }
            mappedData.Latitude = data["results"][0]["geometry"]["location"]["lat"].ToString();
            mappedData.Longitude = data["results"][0]["geometry"]["location"]["lng"].ToString();
            mappedData.IsValid = true;
            return mappedData;
        }
    }
}