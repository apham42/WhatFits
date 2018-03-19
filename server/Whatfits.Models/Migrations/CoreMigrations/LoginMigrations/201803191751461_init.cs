namespace Whatfits.Models.Migrations.CoreMigrations.LoginMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TokenBlackLists",
                c => new
                    {
                        TokenBlackListID = c.Int(nullable: false, identity: true),
                        Tokens = c.String(),
                    })
                .PrimaryKey(t => t.TokenBlackListID);   
        }
        
        public override void Down()
        {
            DropTable("dbo.TokenBlackLists");
        }
    }
}
