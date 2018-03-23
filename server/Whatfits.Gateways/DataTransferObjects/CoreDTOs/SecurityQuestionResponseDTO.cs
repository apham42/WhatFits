using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.Interfaces;
namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    /// <summary>
    ///  Contains the list of security questions from the database
    ///  and information of the status of the request
    /// </summary>
    public class SecurityQuestionResponseDTO: IResponseDTO
    {
        public List<string> Questions { get; set; }
        public List<string> Messages { get; set; }
        public bool isSuccessful { get; set; }
    }
}
