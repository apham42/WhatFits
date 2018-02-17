namespace server.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Whatfits.Models;



    internal sealed class Configuration : DbMigrationsConfiguration<server.Context.WhatfitsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(server.Context.WhatfitsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(x => x.UserID,
                new Models.User()
                {
                    UserID = 0001,
                    FirstName = "Luke",
                    Email = "asdf@gmail.com",
                    LastName = "Atmey",
                    Gender = "Male"
                },
                new Models.User()
                {
                    UserID = 0002,
                    FirstName = "April",
                    LastName = "May",
                    Email = "asdf@gmail.com",
                    Gender = "Female"
                },
                new Models.User()
                {
                    UserID = 0003,
                    FirstName = "Rock",
                    LastName = "Strong",
                    Email = "asdf@live.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    UserID = 0004,
                    FirstName = "Red",
                    LastName = "Blue",
                    Email = "asdf@yahoo.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    UserID = 0005,
                    FirstName = "Cody",
                    LastName = "Hackins",
                    Email = "zzz@channel.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    UserID = 0006,
                    FirstName = "Winston",
                    LastName = "Payne",
                    Email = "jdjd@hotmail.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    UserID = 0007,
                    FirstName = "Jack",
                    LastName = "Hammers",
                    Email = "qwer@facebook.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    UserID = 0008,
                    FirstName = "Penny",
                    LastName = "Nichols",
                    Email = "pn@live.com",
                    Gender = "Female"
                },
                new Models.User()
                {
                    UserID = 0009,
                    FirstName = "Cindy",
                    LastName = "Stone",
                    Email = "poui@live.com",
                    Gender = "Female"
                },
                new Models.User()
                {
                    UserID = 0010,
                    FirstName = "Dee",
                    LastName = "Vasquez",
                    Email = "ohhoho@hotmail.com",
                    Gender = "Female"
                }
                );
            context.Credentials.AddOrUpdate(x => x.UserNameID,
                new Models.Credential()
                {
                    UserID = 0001,
                    UserNameID = "latmey",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0002,
                    UserNameID = "amay",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0003,
                    UserNameID = "rstrong",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0004,
                    UserNameID = "rblue",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0005,
                    UserNameID = "chackins",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0006,
                    UserNameID = "wpayne",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0007,
                    UserNameID = "jhammers",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0008,
                    UserNameID = "pnichols",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0009,
                    UserNameID = "cstone",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0010,
                    UserNameID = "dvasquez",
                    Password = "123456",
                }
                );

            context.Locations.AddOrUpdate(x => x.Address,
                new Models.Location()
                {
                    UserID = 0001,
                    LocationID = 0001,
                    Address = "1865 Locust Court",
                    City = "Long Beach",
                    State = "California",
                    Zipcode = "90840"
                },
                new Models.Location()
                {
                    UserID = 0002,
                    LocationID = 0002,
                    Address = "4358 Maple Lane",
                    City = "Long Beach",
                    State = "California",
                    Zipcode = "90840"
                },
                new Models.Location()
                {
                    UserID = 0003,
                    LocationID = 0003,
                    Address = "2962 Sharon Lane",
                    City = "Long Beach",
                    State = "California",
                    Zipcode = "90840"
                },
                new Models.Location()
                {
                    UserID = 0004,
                    LocationID = 0004,
                    Address = "3782 Jennifer Lane",
                    City = "Long Beach",
                    State = "California",
                    Zipcode = "90840"
                },
                new Models.Location()
                {
                    UserID = 0005,
                    LocationID = 0005,
                    Address = "7059 Roehampton Ave. ",
                    City = "Long Beach",
                    State = "California",
                    Zipcode = "90840"
                },
                new Models.Location()
                {
                    UserID = 0006,
                    LocationID = 0006,
                    Address = "2962 Sharon Lane",
                    City = "Los Angeles",
                    State = "California",
                    Zipcode = "90061"
                },
                new Models.Location()
                {
                    UserID = 0007,
                    LocationID = 0007,
                    Address = "409 E. Depot Ave. ",
                    City = "Los Angeles",
                    State = "California",
                    Zipcode = "90061"
                },
                new Models.Location()
                {
                    UserID = 0008,
                    LocationID = 0008,
                    Address = "446 Meadowbrook St. ",
                    City = "Los Angeles",
                    State = "California",
                    Zipcode = "90061"
                },
                new Models.Location()
                {
                    UserID = 0009,
                    LocationID = 0009,
                    Address = "568 Hickory Avenue ",
                    City = "Los Angeles",
                    State = "California",
                    Zipcode = "90061"
                },
                new Models.Location()
                {
                    UserID = 0010,
                    LocationID = 0010,
                    Address = "61 E. Military Ave. ",
                    City = "Los Angeles",
                    State = "California",
                    Zipcode = "90061"
                }
                );
        }
    }
}
