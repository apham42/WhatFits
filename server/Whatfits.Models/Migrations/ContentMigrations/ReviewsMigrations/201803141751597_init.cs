namespace Whatfits.Models.Migrations.ContentMigrations.ReviewsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        ReviewID = c.Int(nullable: false),
                        RevieweeID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ReviewMessage = c.String(nullable: false),
                        DateTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ReviewID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID); 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropTable("dbo.Reviews");
        }
    }
}
