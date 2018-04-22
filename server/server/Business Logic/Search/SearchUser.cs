using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
using server.Interfaces;
using server.Model;
using Whatfits.DataAccess.Gateways.ContentGateways;

namespace server.Business_Logic.Search
{
    public class SearchUser: ICommand
    {
       public UsernameDTO User { get; set; }

       public Outcome Execute ()
       {
            var result = new Outcome()
            {
                Result = new SearchGateway().SearchUser(User)
            };
            return result;
       }

    }
}