namespace Whatfits.Models.Migrations.ContentMigrations.FollowsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Followers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PersonFollowing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowingID)
                .ForeignKey("dbo.UserProfiles", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "UserID", "dbo.UserProfiles");
            DropIndex("dbo.Followings", new[] { "UserID" });
            DropTable("dbo.Followings");
        }
    }
}
