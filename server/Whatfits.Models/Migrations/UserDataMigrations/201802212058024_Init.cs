namespace Whatfits.Models.Migrations.UserDataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimID = c.Int(nullable: false, identity: true),
                        ClaimsType = c.String(),
                        ClaimsValue = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClaimID)
                .ForeignKey("dbo.Credentials", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PersonalKeys",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Credentials", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.SecurityAnswers",
                c => new
                    {
                        SecurityAnswerID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        SecurityQuestionID = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.SecurityAnswerID)
                .ForeignKey("dbo.SecurityQuestions", t => t.SecurityQuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityAnswers", "UserID", "dbo.Users");
            DropForeignKey("dbo.SecurityAnswers", "SecurityQuestionID", "dbo.SecurityQuestions");
            DropForeignKey("dbo.PersonalKeys", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.Locations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Claims", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.Credentials", "UserID", "dbo.Users");
            DropIndex("dbo.SecurityAnswers", new[] { "SecurityQuestionID" });
            DropIndex("dbo.SecurityAnswers", new[] { "UserID" });
            DropIndex("dbo.PersonalKeys", new[] { "UserID" });
            DropIndex("dbo.Locations", new[] { "UserID" });
            DropIndex("dbo.Credentials", new[] { "UserID" });
            DropIndex("dbo.Claims", new[] { "UserID" });
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.SecurityAnswers");
            DropTable("dbo.PersonalKeys");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Credentials");
            DropTable("dbo.Claims");
        }
    }
}
