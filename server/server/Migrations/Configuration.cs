namespace server.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //using Whatfits.Models;

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
<<<<<<< HEAD:server/Whatfits.Models/Migrations/Configuration.cs
            context.Users.AddOrUpdate(x => x.ID,
                new User()
=======
            context.Users.AddOrUpdate(x => x.UserID,
                new Models.User()
>>>>>>> parent of 3f90cf7... Entityframework moved:server/server/Migrations/Configuration.cs
                {
                    ID = 0001,
                    FirstName = "Luke",
                    Email = "asdf@gmail.com",
                    LastName = "Atmey",
                    Gender = "Male"
                },
                new Models.User()
                {
                    ID = 0002,
                    FirstName = "April",
                    LastName = "May",
                    Email = "asdf@gmail.com",
                    Gender = "Female"
                },
                new Models.User()
                {
                    ID = 0003,
                    FirstName = "Rock",
                    LastName = "Strong",
                    Email = "asdf@live.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    ID = 0004,
                    FirstName = "Red",
                    LastName = "Blue",
                    Email = "asdf@yahoo.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    ID = 0005,
                    FirstName = "Cody",
                    LastName = "Hackins",
                    Email = "zzz@channel.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    ID = 0006,
                    FirstName = "Winston",
                    LastName = "Payne",
                    Email = "jdjd@hotmail.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    ID = 0007,
                    FirstName = "Jack",
                    LastName = "Hammers",
                    Email = "qwer@facebook.com",
                    Gender = "Male"
                },
                new Models.User()
                {
                    ID = 0008,
                    FirstName = "Penny",
                    LastName = "Nichols",
                    Email = "pn@live.com",
                    Gender = "Female"
                },
                new Models.User()
                {
                    ID = 0009,
                    FirstName = "Cindy",
                    LastName = "Stone",
                    Email = "poui@live.com",
                    Gender = "Female"
                },
                new Models.User()
                {
                    ID = 0010,
                    FirstName = "Dee",
                    LastName = "Vasquez",
                    Email = "ohhoho@hotmail.com",
                    Gender = "Female"
                }
                );
<<<<<<< HEAD:server/Whatfits.Models/Migrations/Configuration.cs
            context.Credentials.AddOrUpdate(x => x.UserID,
                new Credential()
=======
            context.Credentials.AddOrUpdate(x => x.UserNameID,
                new Models.Credential()
>>>>>>> parent of 3f90cf7... Entityframework moved:server/server/Migrations/Configuration.cs
                {
                    UserID = 0001,
                    UserName = "latmey",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0002,
                    UserName = "amay",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0003,
                    UserName = "rstrong",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0004,
                    UserName = "rblue",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0005,
                    UserName = "chackins",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0006,
                    UserName = "wpayne",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0007,
                    UserName = "jhammers",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0008,
                    UserName = "pnichols",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0009,
                    UserName = "cstone",
                    Password = "123456",
                },
                new Models.Credential()
                {
                    UserID = 0010,
                    UserName = "dvasquez",
                    Password = "123456",
                }
                );

            context.Locations.AddOrUpdate(x => x.LocationID,
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
            context.Events.AddOrUpdate(x => x.EventID,
                new Models.Event() {
                    EventID = 0000,
                    UserID = 0001,
                    Title = "Nature Walk Tonight",
                    Description = "A brisk walk through as a group tonight.",
                    DateTime = "Saturday, March 22, 2018 @ 8:30pm",
                    Location = "Jefferson Park",
                    CreatedAt = "2018-02-17T18:02:16"
                },
                new Models.Event()
                {
                    EventID = 0001,
                    UserID = 0002,
                    Title = "Gold's Gym Basketball Challenge",
                    Description = "Groups will be made by 11am. Come and compete.",
                    DateTime = "Friday, Feburary 12, 2018 @ 11:00am",
                    Location = "Gold's Gym",
                    CreatedAt = "2018-03-16T04:02:16"
                },
                new Models.Event()
                {
                    EventID = 0002,
                    UserID = 0003,
                    Title = "Relaxing Yoga",
                    Description = "This is a description",
                    DateTime = "Friday, Feburary 12, 2018 @ 11:00am",
                    Location = "This is a location",
                    CreatedAt = "2018-02-19T23:02:16"
                }
                );
            /*
            context.PersonalKeys.AddOrUpdate(x => x.PersonalKeyID,
                    new PersonalKey()
                    {
                        CredentialID = 1,
                        Salt = "asdf"
                    },
                    new PersonalKey()
                    {
                        CredentialID = 2,
                        Salt = "zxc"
                    },
                    new PersonalKey()
                    {
                        CredentialID = 3,
                        Salt = "sdfsdfs"
                    }
                );
                */
        }
    }
}
