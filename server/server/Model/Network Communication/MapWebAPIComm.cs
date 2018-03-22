using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using server.Model.Data_Transfer_Objects.Network_Communication_DTO_s;
using server.Interfaces;


namespace server.Model.Network_Communication
{
    public class MapWebAPIComm : INetworkCommunication<NetworkLocationResponseDTO, NetworkLocationDTO>
    {
        public string mapWebAPI = ConfigurationManager.AppSettings["mapURL"];
        public string mapWebKey = ConfigurationManager.AppSettings["mapKey"];
        public MapWebAPIComm()
        {

        }
        public async Task<NetworkLocationResponseDTO> Request(NetworkLocationDTO dto)
        {
            string api = ConfigurationManager.AppSettings["mapURL"];
            string key = ConfigurationManager.AppSettings["mapKey"];
            NetworkLocationResponseDTO responseDTO;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(mapWebAPI + dto.Location + mapWebKey);
                responseDTO = new NetworkLocationResponseDTO()
                {
                    Response = response
                };
                return responseDTO;
            }
        }
    }
}