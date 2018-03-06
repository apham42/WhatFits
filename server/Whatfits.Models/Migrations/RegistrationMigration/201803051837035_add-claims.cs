namespace Whatfits.Models.Migrations.RegistrationMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclaims : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claims", "UserID", "dbo.Credentials");
            DropIndex("dbo.Claims", new[] { "UserID" });
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        UserClaimsID = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ClaimID = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserClaimsID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            DropColumn("dbo.Claims", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claims", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserClaims", "UserID", "dbo.Users");
            DropIndex("dbo.UserClaims", new[] { "UserID" });
            DropTable("dbo.UserClaims");
            CreateIndex("dbo.Claims", "UserID");
            AddForeignKey("dbo.Claims", "UserID", "dbo.Credentials", "UserID", cascadeDelete: true);
        }
    }
}
