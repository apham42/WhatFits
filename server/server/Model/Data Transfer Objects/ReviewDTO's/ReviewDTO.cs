using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Interfaces;

namespace server.Data_Transfer_Objects.ReviewDTO_s
{
    public class ReviewDTO
    {
        public string message { get; set; }
        public bool status { get; set; }
    }
}