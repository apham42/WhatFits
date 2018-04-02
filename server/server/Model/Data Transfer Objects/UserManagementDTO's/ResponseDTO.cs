using System.Collections.Generic;

namespace server.Model.Data_Transfer_Objects.UserManagementDTO_s
{
    public class ResponseDTO<T>
    {
        public ResponseDTO()
        {
            Messages = new List<string>();
        }
        public ResponseDTO(T obj)
        {
            Data = obj;
            Messages = new List<string>();
        }
        public T Data { get; set; }
        public List<string> Messages { get; set; }
        public bool IsSuccessful { get; set; }
    }
}