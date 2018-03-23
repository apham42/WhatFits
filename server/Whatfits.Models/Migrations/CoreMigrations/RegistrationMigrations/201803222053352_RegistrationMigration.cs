namespace Whatfits.Models.Migrations.CoreMigrations.RegistrationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "Gender", c => c.String());
            AlterColumn("dbo.Users", "SkillLevel", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SkillLevel", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Gender", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
