using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Account
{
    /// <summary>
    /// Contains one of the security question and answer that the 
    /// user entered for registration
    /// </summary>
    public class SecurityQuestion
    {
        public SecurityQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public string Question { get; private set; }
        public string Answer { get; private set; }
    }
}