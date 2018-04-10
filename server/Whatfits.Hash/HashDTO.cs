using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.Hash
{
    /// <summary>
    /// DTO for Hash. Original should have the salt if it is needed.
    /// </summary>
    public class HashDTO
    {
        public string Original { get; set; }
    }
}