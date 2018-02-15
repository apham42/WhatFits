using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.App_Start
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new WhatfitsContext())
            {
                User user = new User()
                {
                    UserName = "New Student"
                };
                ctx.User.Add(user);
                ctx.SaveChanges();
            }
        }
    }
}