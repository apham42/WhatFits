using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace server.Context
{
    interface IDataGateways<T> where T:class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(int? id);
        void Insert(T obj);
        void Update(T obj);
        T Delete(int? id);
        void Save();
    }
}
