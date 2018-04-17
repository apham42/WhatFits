using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Search
{
    public class SearchResult
    {
        public SearchResult(string user, string skill, double distance)
        {
            Username = user;
            SkillLevel = skill;
            Distance = distance;
        }

        public string Username { get; private set; }
        public string SkillLevel { get; private set; }
        public double Distance { get; private set; }
    }
}