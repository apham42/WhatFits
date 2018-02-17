namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCredLoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        UserNameID = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserNameID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Address = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Address)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Credentials", "UserID", "dbo.Users");
            DropIndex("dbo.Locations", new[] { "UserID" });
            DropIndex("dbo.Credentials", new[] { "UserID" });
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Credentials");
        }
    }
}
