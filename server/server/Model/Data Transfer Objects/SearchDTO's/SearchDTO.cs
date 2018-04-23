using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.Model.Search;

namespace server.Model.Data_Transfer_Objects.SearchDTO_s
{
    public class SearchDTO
    {
        public string User { get; set; }
        public SearchCriteria Criteria { get; set; }
    }
}