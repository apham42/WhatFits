using server.Interfaces;
using server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Business_Logic.Reset_Password
{
    public class GetQuestions : ICommand
    {
        public Outcome Execute()
        {
            var response = new Outcome();

            return response;
        }
    }
}