﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Interfaces
{
    interface IResponseDTO
    {
        string message { get; set; }
        bool status { get; set; }
    }
}
