namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cardio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cardios",
                c => new
                    {
                        CardioID = c.Int(nullable: false, identity: true),
                        WorkoutID = c.Int(nullable: false),
                        CardioType = c.String(),
                        Distance = c.Int(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.CardioID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.WorkoutID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cardios", "WorkoutID", "dbo.WorkoutLogs");
            DropIndex("dbo.Cardios", new[] { "WorkoutID" });
            DropTable("dbo.Cardios");
        }
    }
}
