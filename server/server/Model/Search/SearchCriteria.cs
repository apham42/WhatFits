using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Search
{
    public class SearchCriteria
    {
        public string RequestedUser { get; set; }
        public string RequestedSearch { get; set; }
        public int? Distance { get; set; }
        public string Skill { get; set; }
    }
}