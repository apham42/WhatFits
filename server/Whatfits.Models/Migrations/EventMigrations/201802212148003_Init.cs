namespace Whatfits.Models.Migrations.EventMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Title = c.String(),
                        CreatedAt = c.String(),
                        DateTime = c.String(),
                        Description = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropIndex("dbo.Events", new[] { "UserID" });
            DropTable("dbo.Events");
        }
    }
}
