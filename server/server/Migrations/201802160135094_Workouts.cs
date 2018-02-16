namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Workouts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkoutLogs",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WorkoutType = c.String(),
                        Date_Time = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.WeightLiftings",
                c => new
                    {
                        WeightLiftingID = c.Int(nullable: false, identity: true),
                        WorkoutID = c.Int(nullable: false),
                        LiftingType = c.String(),
                        sets = c.Int(nullable: false),
                        reps = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeightLiftingID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.WorkoutID);
            
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "State", c => c.String());
            AddColumn("dbo.Users", "Zipcode", c => c.String());
            DropColumn("dbo.Users", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Gender", c => c.String());
            DropForeignKey("dbo.WeightLiftings", "WorkoutID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.WorkoutLogs", "UserID", "dbo.Users");
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutID" });
            DropIndex("dbo.WorkoutLogs", new[] { "UserID" });
            DropColumn("dbo.Users", "Zipcode");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "City");
            DropTable("dbo.WeightLiftings");
            DropTable("dbo.WorkoutLogs");
        }
    }
}
