using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            IList<User> defaultUser = new List<User>();
            defaultUser.Add(new User() { UserID = 0001,UserName = "Tom123", Password= "asdf"});
            defaultUser.Add(new User() { UserID = 0002, UserName = "Emily123",Password = "asdf" });
            defaultUser.Add(new User() { UserID = 0003, UserName = "John123", Password = "asdf" });
            defaultUser.Add(new User() { UserID = 0005, UserName = "Max123", Password = "asdf" });
            foreach (User usr in defaultUser)
                context.User.Add(usr);
            base.Seed(context);
        }
    }
}