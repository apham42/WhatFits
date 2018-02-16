namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpermissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
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
            DropForeignKey("dbo.UserPermissions", "UserID", "dbo.Users");
            DropIndex("dbo.Cardios", new[] { "WorkoutID" });
            DropIndex("dbo.UserPermissions", new[] { "UserID" });
            DropTable("dbo.Cardios");
            DropTable("dbo.UserPermissions");
        }
    }
}
