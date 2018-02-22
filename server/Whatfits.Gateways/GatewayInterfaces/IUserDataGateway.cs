using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Gateways.GatewayInterfaces
{
    interface IUserDataGateway<T> where T : class
    {
        void CreateUser();
        void DeleteUser();
        void UpdateUser();
        void DisableUser();
        void EnableUser();
        int SelectbyUserID();
        T FindbyUserID();
        void CreatePartialUser();
        IEnumerable<T> SelectAll();
        void SetClaim(IEnumerable<T> obj);
        void RemoveClaim();
        void Save();
    }
}
