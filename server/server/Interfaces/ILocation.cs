using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface ILocation
    {
        string Street { get; set; }
        string City { get; set; }
        string ZipCode { get; set; }
        string State { get; set; }

        string getLocation();
    }
}
