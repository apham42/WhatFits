using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.Interfaces;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    /// <summary>
    /// Contains information if the username exists from the database
    /// </summary>
    public class UsernameResponseDTO: IResponseDTO
    {
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }
    }
}
