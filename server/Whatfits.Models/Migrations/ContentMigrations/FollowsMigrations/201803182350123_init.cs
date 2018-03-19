namespace Whatfits.Models.Migrations.ContentMigrations.FollowsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowingID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        PersonFollowing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowingID, t.UserID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "UserID", "dbo.Users");
            DropIndex("dbo.Followings", new[] { "UserID" });
            DropTable("dbo.Followings");
        }
    }
}
