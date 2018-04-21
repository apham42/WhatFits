using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Whatfits.Models.Models;

namespace server.Business_Logic.Services
{
    public class FollowsService : ICollection<FollowsDTO>
    {
        private bool addstatus = false;
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(FollowsDTO follo)
        {
            var gateway = new FollowsGateway();
            gateway.AddtoFollow(follo);
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

        public void CopyTo(FollowsDTO[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<FollowsDTO> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(FollowsDTO item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}