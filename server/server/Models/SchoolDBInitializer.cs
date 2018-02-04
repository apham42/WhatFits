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
            IList<Standard> defaultStandards = new List<Standard>();
            defaultStandards.Add(new Standard() { StanadardName = "Tom", StandardId = 00 });
            defaultStandards.Add(new Standard() { StanadardName = "Alex", StandardId = 01 });
            defaultStandards.Add(new Standard() { StanadardName = "Wick", StandardId = 02 });
            defaultStandards.Add(new Standard() { StanadardName = "Johnson", StandardId = 03});
            foreach (Standard std in defaultStandards)
                context.Standards.Add(std);
            base.Seed(context);
        }
    }
}