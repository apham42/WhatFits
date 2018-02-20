namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class claims : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimID = c.Int(nullable: false, identity: true),
                        PermissionType = c.String(),
                        PermissionValue = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClaimID)
                .ForeignKey("dbo.Credentials", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Credentials", "Role", c => c.String());
            DropColumn("dbo.Credentials", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credentials", "Salt", c => c.String());
            DropForeignKey("dbo.Claims", "UserID", "dbo.Credentials");
            DropIndex("dbo.Claims", new[] { "UserID" });
            DropColumn("dbo.Credentials", "Role");
            DropTable("dbo.Claims");
        }
    }
}
