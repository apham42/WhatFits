namespace Whatfits.Models.Migrations.AccountMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "Email", c => c.String());
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String());
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String());
            AlterColumn("dbo.UserProfiles", "Gender", c => c.String());
            AlterColumn("dbo.UserProfiles", "SkillLevel", c => c.String());
            AlterColumn("dbo.UserProfiles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.UserProfiles", "SkillLevel", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.UserProfiles", "Gender", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "Email", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
