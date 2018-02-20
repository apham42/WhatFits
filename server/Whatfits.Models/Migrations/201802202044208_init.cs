namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalKeys", "UserID", "dbo.Users");
            AddColumn("dbo.Credentials", "Salt", c => c.String());
            AddForeignKey("dbo.PersonalKeys", "UserID", "dbo.Credentials", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalKeys", "UserID", "dbo.Credentials");
            DropColumn("dbo.Credentials", "Salt");
            AddForeignKey("dbo.PersonalKeys", "UserID", "dbo.Users", "ID");
        }
    }
}
