namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datanote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cardios", "WorkoutID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.WeightLiftings", "WorkoutID", "dbo.WorkoutLogs");
            DropIndex("dbo.Cardios", new[] { "WorkoutID" });
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutID" });
            AddColumn("dbo.Cardios", "WorkoutLog_WorkoutLogID", c => c.Int());
            AddColumn("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", c => c.Int());
            CreateIndex("dbo.Cardios", "WorkoutLog_WorkoutLogID");
            CreateIndex("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID");
            AddForeignKey("dbo.Cardios", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs", "WorkoutLogID");
            AddForeignKey("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs", "WorkoutLogID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.Cardios", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID" });
            DropIndex("dbo.Cardios", new[] { "WorkoutLog_WorkoutLogID" });
            DropColumn("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID");
            DropColumn("dbo.Cardios", "WorkoutLog_WorkoutLogID");
            CreateIndex("dbo.WeightLiftings", "WorkoutID");
            CreateIndex("dbo.Cardios", "WorkoutID");
            AddForeignKey("dbo.WeightLiftings", "WorkoutID", "dbo.WorkoutLogs", "WorkoutLogID", cascadeDelete: true);
            AddForeignKey("dbo.Cardios", "WorkoutID", "dbo.WorkoutLogs", "WorkoutLogID", cascadeDelete: true);
        }
    }
}
