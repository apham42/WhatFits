using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Data_Transfer_Objects.ReviewDTO_s
{
    public class ResponseDTO<T>
    {
        public List<string> Messages { get; set; }
        public T isSuccessful { get; set; }
    }
}