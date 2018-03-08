namespace Whatfits.Models.Migrations.ContentMigrations.WorkoutLogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        WorkoutLog_WorkoutLogID = c.Int(),
                    })
                .PrimaryKey(t => t.CardioID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutLog_WorkoutLogID)
                .Index(t => t.WorkoutLog_WorkoutLogID);
            
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

            CreateTable(
                "dbo.WeightLiftings",
                c => new
                    {
                        WeightLiftingID = c.Int(nullable: false, identity: true),
                        WorkoutID = c.Int(nullable: false),
                        LiftingType = c.String(),
                        Sets = c.Int(nullable: false),
                        Reps = c.Int(nullable: false),
                        WorkoutLog_WorkoutLogID = c.Int(),
                    })
                .PrimaryKey(t => t.WeightLiftingID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutLog_WorkoutLogID)
                .Index(t => t.WorkoutLog_WorkoutLogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.WorkoutLogs", "UserID", "dbo.Users");
            DropForeignKey("dbo.Cardios", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID" });
            DropIndex("dbo.WorkoutLogs", new[] { "UserID" });
            DropIndex("dbo.Cardios", new[] { "WorkoutLog_WorkoutLogID" });
            DropTable("dbo.WeightLiftings");
            DropTable("dbo.WorkoutLogs");
            DropTable("dbo.Cardios");
        }
    }
}
