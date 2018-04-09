using System.Collections.Generic;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs
{
    public class ResponseDTO<T> : IResponseDTO
    {
        public T Data { get; set; }
        public List<string> Messages { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
