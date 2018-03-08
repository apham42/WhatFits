namespace Whatfits.Models.Migrations.ContentMigrations.FollowsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {   
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FollowingPerson = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowerID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PersonFollowing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowingID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Followers", "UserID", "dbo.Users");
            DropIndex("dbo.Followings", new[] { "UserID" });
            DropIndex("dbo.Followers", new[] { "UserID" });
            DropTable("dbo.Followings");
            DropTable("dbo.Followers");
        }
    }
}
