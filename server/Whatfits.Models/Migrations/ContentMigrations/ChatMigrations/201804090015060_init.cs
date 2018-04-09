namespace Whatfits.Models.Migrations.ContentMigrations.ChatMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        MessageContent = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.UserProfiles", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "UserID", "dbo.UserProfiles");
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropTable("dbo.Messages");
        }
    }
}
