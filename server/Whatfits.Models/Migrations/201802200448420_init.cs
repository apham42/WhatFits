namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalKeys",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalKeys", "UserID", "dbo.Users");
            DropIndex("dbo.PersonalKeys", new[] { "UserID" });
            DropTable("dbo.PersonalKeys");
        }
    }
}
