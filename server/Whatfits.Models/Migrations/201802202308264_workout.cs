namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkoutLogs",
                c => new
                    {
                        WorkoutLogID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WorkoutType = c.String(),
                        Date_Time = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutLogID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutLogs", "UserID", "dbo.Users");
            DropIndex("dbo.WorkoutLogs", new[] { "UserID" });
            DropTable("dbo.WorkoutLogs");
        }
    }
}
