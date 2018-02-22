using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Gateways.GatewayInterfaces
{
    interface IUser
    {
        void UpdateUser();
        void UpdateCredentials();
        void UpdateLocation();
    }
}
