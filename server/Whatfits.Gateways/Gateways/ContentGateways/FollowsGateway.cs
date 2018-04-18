﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;

namespace Whatfits.DataAccess.Gateways.ContentGateways
{
    public class FollowsGateway
    {
        private FollowsContext db = new FollowsContext();

        public bool DoesUserNameExists(Credential obj)
        {
            // Find username inside database based on obj.UserName
            var foundUserName = (from credentials in db.Crendtials
                                 where credentials.UserName == obj.UserName
                                 select credentials.UserName).FirstOrDefault();
            // Checking if it found a user
            if (foundUserName == null)
                // returns false if passed username does not exists in database
                return false;
            else
                // returns true if passed username does exists in database
                return true;
        }
    }
}
