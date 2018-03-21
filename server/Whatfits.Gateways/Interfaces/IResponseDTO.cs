using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.Interfaces
{
    public interface IResponseDTO
    {
        List<string> Messages { get; set; }
        bool isSuccessful { get; set; }
    }
}
