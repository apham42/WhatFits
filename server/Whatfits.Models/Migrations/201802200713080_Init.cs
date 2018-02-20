namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chatrooms",
                c => new
                    {
                        ChatroomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.String(),
                    })
                .PrimaryKey(t => t.ChatroomID);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        UserNameID = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserNameID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Title = c.String(),
                        CreatedAt = c.String(),
                        DateTime = c.String(),
                        Description = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ChatroomID = c.Int(nullable: false),
                        MessageContent = c.String(),
                        CreatedAt = c.String(),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Chatrooms", t => t.ChatroomID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ChatroomID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Credentials", "UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatroomID", "dbo.Chatrooms");
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropIndex("dbo.Locations", new[] { "UserID" });
            DropIndex("dbo.Messages", new[] { "ChatroomID" });
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Credentials", new[] { "UserID" });
            DropTable("dbo.Locations");
            DropTable("dbo.Messages");
            DropTable("dbo.Events");
            DropTable("dbo.Users");
            DropTable("dbo.Credentials");
            DropTable("dbo.Chatrooms");
        }
    }
}
