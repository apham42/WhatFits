using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Whatfits.DataAccess.DTOs
{
    public class Coordinate
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
