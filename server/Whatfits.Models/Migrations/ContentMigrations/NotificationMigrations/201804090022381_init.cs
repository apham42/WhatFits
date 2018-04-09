namespace Whatfits.Models.Migrations.ContentMigrations.NotificationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        NotificationType = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.UserProfiles", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserID", "dbo.UserProfiles");
            
            DropIndex("dbo.Notifications", new[] { "UserID" });
            
            DropTable("dbo.Notifications");
            
        }
    }
}
