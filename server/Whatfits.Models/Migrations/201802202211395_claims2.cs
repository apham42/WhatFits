namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class claims2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "ClaimsType", c => c.String());
            AddColumn("dbo.Claims", "ClaimsValue", c => c.String());
            DropColumn("dbo.Claims", "PermissionType");
            DropColumn("dbo.Claims", "PermissionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claims", "PermissionValue", c => c.String());
            AddColumn("dbo.Claims", "PermissionType", c => c.String());
            DropColumn("dbo.Claims", "ClaimsValue");
            DropColumn("dbo.Claims", "ClaimsType");
        }
    }
}
