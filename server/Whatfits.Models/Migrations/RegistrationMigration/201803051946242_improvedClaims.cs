namespace Whatfits.Models.Migrations.RegistrationMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class improvedClaims : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserClaims", "ClaimID", c => c.Int(nullable: false));
            DropColumn("dbo.UserClaims", "ClaimType");
            DropColumn("dbo.UserClaims", "ClaimValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserClaims", "ClaimValue", c => c.String());
            AddColumn("dbo.UserClaims", "ClaimType", c => c.String());
            AlterColumn("dbo.UserClaims", "ClaimID", c => c.String());
        }
    }
}
