namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _event : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Location = c.String(),
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
