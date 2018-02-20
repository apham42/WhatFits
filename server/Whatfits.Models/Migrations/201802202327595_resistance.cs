namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resistance : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID" });
            DropTable("dbo.WeightLiftings");
        }
    }
}
