using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.Model;

namespace server.Interfaces
{
    public interface ICommand
    {
        Outcome Execute();
    }
}
