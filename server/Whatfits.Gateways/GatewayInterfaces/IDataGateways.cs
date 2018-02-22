using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Whatfits.Gateways
{
    interface IDataGateways<T> where T:class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(int? id);
        T SelectByUserName(string userName);
        void Insert(T obj);
        void Update(T obj);
        T Delete(int? id);
        void Save();
    }
}
