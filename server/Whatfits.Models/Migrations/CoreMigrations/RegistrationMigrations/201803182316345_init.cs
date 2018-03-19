namespace Whatfits.Models.Migrations.CoreMigrations.RegistrationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClaimItems",
                c => new
                    {
                        ClaimID = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(nullable: false, maxLength: 80),
                        ClaimValue = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.ClaimID);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.SecurityQandAs",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        SecurityQuestionID = c.Int(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.SecurityQuestionID })
                .ForeignKey("dbo.Credentials", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.SecurityQuestions", t => t.SecurityQuestionID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SecurityQuestionID);
            
            CreateTable(
                "dbo.SecurityQuestions",
                c => new
                    {
                        SecurityQuestionID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.SecurityQuestionID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 256),
                        ProfilePicture = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 50),
                        SkillLevel = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 250),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Credentials", t => t.UserID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);

            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        ClaimID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClaimID, t.UserID })
                .ForeignKey("dbo.ClaimItems", t => t.ClaimID, cascadeDelete: true)
                .ForeignKey("dbo.Credentials", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ClaimID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Salts",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        SaltValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Credentials", t => t.UserID)
                .Index(t => t.UserID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salts", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.UserClaims", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.UserClaims", "ClaimID", "dbo.ClaimItems");
            DropForeignKey("dbo.Users", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Users", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.SecurityQandAs", "SecurityQuestionID", "dbo.SecurityQuestions");
            DropForeignKey("dbo.SecurityQandAs", "UserID", "dbo.Credentials");
            DropIndex("dbo.Salts", new[] { "UserID" });
            DropIndex("dbo.UserClaims", new[] { "UserID" });
            DropIndex("dbo.UserClaims", new[] { "ClaimID" });
            DropIndex("dbo.Users", new[] { "LocationID" });
            DropIndex("dbo.Users", new[] { "UserID" });
            DropIndex("dbo.SecurityQandAs", new[] { "SecurityQuestionID" });
            DropIndex("dbo.SecurityQandAs", new[] { "UserID" });
            DropTable("dbo.Salts");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.SecurityQandAs");
            DropTable("dbo.Credentials");
            DropTable("dbo.ClaimItems");
        }
    }
}
