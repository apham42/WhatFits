using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Standard
    {
        public Standard()
        {

        }
        public int StandardId { get; set; }
        public string StanadardName { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}