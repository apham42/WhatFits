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
                        Location = c.String(),
                        Title = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.UserProfiles", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserID", "dbo.UserProfiles");
            DropIndex("dbo.Events", new[] { "UserID" });
            DropTable("dbo.Events");
        }
    }
}
