using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models;
namespace Whatfits.Gateways.DataTransferObjects
{
    public class CreateUserDTO
    {
        private User user = new User();
        private Credential credential = new Credential();
        private Location location = new Location();
        private PersonalKey personalkey = new PersonalKey();
        private SecurityAnswer answers = new SecurityAnswer();
        private SecurityQuestion questions = new SecurityQuestion();
        public CreateUserDTO()
        {
            
        }
        public void InsertUser(User obj)
        {
            user = obj;
        }
        public User ReceiveUser()
        {
            return user;
        }
        public void InsertCredential(Credential obj)
        {
            credential = obj;
        }
        public Credential ReceiveCredential()
        {
            return credential;
        }
        public void InsertLocation(Location obj)
        {
            location = obj;
        }
        public Location RecieveLocation()
        {
            return location;
        }
        public void  InsertPersonalKey(PersonalKey obj)
        {
            personalkey = obj;
        }
        public PersonalKey ReceivePersonalKey(PersonalKey obj)
        {
            return personalkey;
        }
        public void InsertSecurityAnswer(SecurityAnswer obj)
        {
            answers = obj;
        }
        public SecurityAnswer ReceiveSecurityAnswer(SecurityAnswer obj)
        {
            return answers;
        }
        public void InsertSecurityQuestion(SecurityAnswer obj)
        {
            answers = obj;
        }
        public SecurityQuestion ReceiveSecurityQuestion(SecurityAnswer obj)
        {
            return questions;
        }
    }
}
