using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Constants
{
    /// <summary>
    /// This class stores the range of the "hits" to determine 
    /// whether the password is too vulnerable.
    /// </summary>
    public class BadPasswordConstants
    {
        public const int MINIMUMRANGE = 50;
        public const int MAXIMUMRANGE = 99;
    }
}