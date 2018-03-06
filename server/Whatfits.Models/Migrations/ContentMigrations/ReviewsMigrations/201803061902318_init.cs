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
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewerID = c.Int(nullable: false),
                        RevieweeID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ReviewMessage = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Users", t => t.ReviewerID, cascadeDelete: true)
                .Index(t => t.ReviewerID); 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ReviewerID", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "ReviewerID" });
            DropTable("dbo.Reviews");
        }
    }
}
