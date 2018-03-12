using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DataTransferObjects.CoreDTOs
{
    public class LoginDTO
    {
        // UserData
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        // Credentials
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsFullyRegistered { get; set; }
        public Boolean Status { get; set; }
        // UserClaims
        public List<int> ClaimIDs { get; set; }
        // Salt
        public string Salt { get; set; }
        // Security Q&A
        public List<int> QuestionIDs { get; set; }
        public List<String> Answers { get; set; }
    }
}
