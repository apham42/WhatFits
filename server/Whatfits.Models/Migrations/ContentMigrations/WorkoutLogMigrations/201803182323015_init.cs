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
                        CardioID = c.Int(nullable: false),
                        WorkoutID = c.Int(nullable: false),
                        CardioType = c.String(nullable: false),
                        Distance = c.Double(nullable: false),
                        Time = c.String(nullable: false),
                        WorkoutLog_WorkoutLogID = c.Int(),
                        WorkoutLog_UserID = c.Int(),
                    })
                .PrimaryKey(t => new { t.CardioID, t.WorkoutID })
                .ForeignKey("dbo.WorkoutLogs", t => new { t.WorkoutLog_WorkoutLogID, t.WorkoutLog_UserID })
                .Index(t => new { t.WorkoutLog_WorkoutLogID, t.WorkoutLog_UserID });
            
            CreateTable(
                "dbo.WorkoutLogs",
                c => new
                    {
                        WorkoutLogID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        WorkoutType = c.String(),
                        Date_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkoutLogID, t.UserID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.WeightLiftings",
                c => new
                    {
                        WeightLiftingID = c.Int(nullable: false),
                        WorkoutID = c.Int(nullable: false),
                        LiftingType = c.String(nullable: false),
                        Sets = c.Int(nullable: false),
                        Reps = c.Int(nullable: false),
                        WorkoutLog_WorkoutLogID = c.Int(),
                        WorkoutLog_UserID = c.Int(),
                    })
                .PrimaryKey(t => new { t.WeightLiftingID, t.WorkoutID })
                .ForeignKey("dbo.WorkoutLogs", t => new { t.WorkoutLog_WorkoutLogID, t.WorkoutLog_UserID })
                .Index(t => new { t.WorkoutLog_WorkoutLogID, t.WorkoutLog_UserID }); 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutLogs", "UserID", "dbo.Users");
            DropForeignKey("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID", "WorkoutLog_UserID" }, "dbo.WorkoutLogs");
            DropForeignKey("dbo.Cardios", new[] { "WorkoutLog_WorkoutLogID", "WorkoutLog_UserID" }, "dbo.WorkoutLogs");
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID", "WorkoutLog_UserID" });
            DropIndex("dbo.WorkoutLogs", new[] { "UserID" });
            DropIndex("dbo.Cardios", new[] { "WorkoutLog_WorkoutLogID", "WorkoutLog_UserID" });
            DropTable("dbo.WeightLiftings");
            DropTable("dbo.WorkoutLogs");
            DropTable("dbo.Cardios");
        }
    }
}
