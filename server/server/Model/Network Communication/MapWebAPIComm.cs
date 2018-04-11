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
    /// <summary>
    /// Sends request to a Map Web API service
    /// </summary>
    public class MapWebAPIComm : INetworkCommunication<NetworkLocationResponseDTO, NetworkLocationDTO>
    {
        /// <summary>
        /// Contents that this needs to send to the Map Web API requires 
        /// </summary>
        private string mapWebAPI = ConfigurationManager.AppSettings["mapURL"];
        private string mapWebKey = ConfigurationManager.AppSettings["mapKey"];
        public MapWebAPIComm()
        {

        }

        /// <summary>
        /// Sends a request to the Map Web API
        /// </summary>
        /// <param name="dto">DTO that contains the data that will be used in the request </param>
        /// <returns> A async Task response DTO that contains the data that was received from the request </returns>
        public async Task<NetworkLocationResponseDTO> Request(NetworkLocationDTO dto)
        {
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