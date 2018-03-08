using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.GatewayInterfaces
{
    interface IDataGateway<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
        int FindByUserName(string userName);
        string FindByID(int id);
        void Save();
    }
}
