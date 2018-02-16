namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Reviewee = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ReviewMessage = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.ReviewID)
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
