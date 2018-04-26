using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.Models.Context.Content;
using Whatfits.Models.Models;

namespace server.Business_Logic.Services
{
    public class FollowsService
    {

        public bool Add(string userName, string follouserName)
        {
            var gateway = new FollowsGateway();
            return gateway.AddtoFollow(userName,follouserName);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string userName, string follouserName)
        {
            var gateway = new FollowsGateway();
            return gateway.IsFollow(userName, follouserName);
        }


        public IEnumerable<FollowsDTO> GetEnumerator(string userName)
        {
            var gateway = new FollowsGateway();
            return gateway.GetFollowers(userName);
        }

        public bool Remove(string userName, string unfolloName)
        {
            var gateway = new FollowsGateway();
            return gateway.DeletefromFollow(userName, unfolloName);
        }
    }
}