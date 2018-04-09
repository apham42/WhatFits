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
                        CardioType = c.String(nullable: false),
                        Distance = c.Double(nullable: false),
                        Time = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CardioID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.WorkoutID);
            
            CreateTable(
                "dbo.WorkoutLogs",
                c => new
                    {
                        WorkoutLogID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WorkoutType = c.String(),
                        Date_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutLogID)
                .ForeignKey("dbo.UserProfiles", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            
            
            CreateTable(
                "dbo.WeightLiftings",
                c => new
                    {
                        WeightLiftingID = c.Int(nullable: false, identity: true),
                        WorkoutID = c.Int(nullable: false),
                        LiftingType = c.String(nullable: false),
                        Sets = c.Int(nullable: false),
                        Reps = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeightLiftingID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.WorkoutID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cardios", "WorkoutID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.WeightLiftings", "WorkoutID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.WorkoutLogs", "UserID", "dbo.UserProfiles");
            
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutID" });
            
            DropIndex("dbo.WorkoutLogs", new[] { "UserID" });
            
            DropTable("dbo.WeightLiftings");
            
            DropTable("dbo.WorkoutLogs");
            DropTable("dbo.Cardios");
        }
    }
}
