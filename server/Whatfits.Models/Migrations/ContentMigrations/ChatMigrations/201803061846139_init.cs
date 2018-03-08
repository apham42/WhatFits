namespace Whatfits.Models.Migrations.ContentMigrations.ChatMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatroomID", "dbo.Chatrooms");
            DropIndex("dbo.Messages", new[] { "ChatroomID" });
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropTable("dbo.Messages");
            DropTable("dbo.Chatrooms");
        }
    }
}
