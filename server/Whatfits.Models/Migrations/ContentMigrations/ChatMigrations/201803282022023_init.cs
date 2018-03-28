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
                        MessageID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        MessageContent = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageID, t.UserID })
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
