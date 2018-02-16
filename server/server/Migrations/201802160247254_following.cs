namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class following : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FollowingEmail = c.String(),
                    })
                .PrimaryKey(t => t.FollowingID)
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
