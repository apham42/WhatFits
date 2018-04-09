namespace Whatfits.Models.Migrations.AccountMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TokenBlackLists", "Token", c => c.String());
            AddColumn("dbo.TokenBlackLists", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.TokenBlackLists", "UserID");
            AddForeignKey("dbo.TokenBlackLists", "UserID", "dbo.Credentials", "UserID", cascadeDelete: true);
            DropColumn("dbo.TokenBlackLists", "Tokens");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TokenBlackLists", "Tokens", c => c.String());
            DropForeignKey("dbo.TokenBlackLists", "UserID", "dbo.Credentials");
            DropIndex("dbo.TokenBlackLists", new[] { "UserID" });
            DropColumn("dbo.TokenBlackLists", "UserID");
            DropColumn("dbo.TokenBlackLists", "Token");
        }
    }
}
