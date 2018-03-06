namespace Whatfits.Models.Migrations.RegistrationMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsPartialRegistration", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsPartialRegistration");
        }
    }
}
