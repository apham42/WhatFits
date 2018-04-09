using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface INetworkCommunication<ResponseDTO, RequestDTO>
    {
        Task<ResponseDTO> Request(RequestDTO req);
    }
}
