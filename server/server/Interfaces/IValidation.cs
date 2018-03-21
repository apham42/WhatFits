using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IValidation<T>
    {
        T Validate<DTO>(DTO obj);
    }
}
