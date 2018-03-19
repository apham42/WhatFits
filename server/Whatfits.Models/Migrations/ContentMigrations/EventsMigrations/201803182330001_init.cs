namespace Whatfits.Models.Migrations.ContentMigrations.EventsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.LocationID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropForeignKey("dbo.Events", "LocationID", "dbo.Locations");
            DropIndex("dbo.Events", new[] { "LocationID" });
            DropIndex("dbo.Events", new[] { "UserID" });
            DropTable("dbo.Events");
        }
    }
}
