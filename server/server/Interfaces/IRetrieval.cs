﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IRetrieval <T>
    {
        bool Retrieve (T obj);
    }
}
