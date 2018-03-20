using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IRequest
    {
        List<T> Request<T>(T location);
    }
}
