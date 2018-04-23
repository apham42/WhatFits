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
        private bool addstatus = false;

        public void Add(FollowsDTO item)
        {
            var gateway = new FollowsGateway();
            gateway.AddtoFollow(item);
            addstatus = true;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(FollowsDTO item)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<FollowsDTO> GetEnumerator(string userName)
        {
            var gateway = new FollowsGateway();
            return gateway.GetFollowers(userName);
        }
        

        public void Insert(int index, FollowsDTO item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(FollowsDTO item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool GetAddStatus()
        {
            return this.addstatus;
        }
    }
}