using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Whatfits.Models;
using Whatfits.Models.Context;
namespace Whatfits.Gateways
{
    public class UserGateway : IDataGateways<User>
    {
        private WhatfitsContext db = new WhatfitsContext();

        public User Delete(int? id)
        {
            User user = SelectByID(id);
            db.Users.Remove(user);
            Save();
            return user;
        }
        public void Insert(User user)
        {
            db.Users.Add(user);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public IEnumerable<User> SelectAll()
        {
            return db.Users.ToList();
        }
        public User SelectByID(int? id)
        {
            return db.Users.Find(id);
        }
        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            Save();
        }
    }
}