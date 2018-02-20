namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutlogcomplete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID" });
            DropColumn("dbo.WeightLiftings", "WorkoutID");
            RenameColumn(table: "dbo.WeightLiftings", name: "WorkoutLog_WorkoutLogID", newName: "WorkoutID");
            AlterColumn("dbo.WeightLiftings", "WorkoutID", c => c.Int(nullable: false));
            CreateIndex("dbo.WeightLiftings", "WorkoutID");
            AddForeignKey("dbo.WeightLiftings", "WorkoutID", "dbo.WorkoutLogs", "WorkoutLogID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeightLiftings", "WorkoutID", "dbo.WorkoutLogs");
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutID" });
            AlterColumn("dbo.WeightLiftings", "WorkoutID", c => c.Int());
            RenameColumn(table: "dbo.WeightLiftings", name: "WorkoutID", newName: "WorkoutLog_WorkoutLogID");
            AddColumn("dbo.WeightLiftings", "WorkoutID", c => c.Int(nullable: false));
            CreateIndex("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID");
            AddForeignKey("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs", "WorkoutLogID");
        }
    }
}
