namespace Whatfits.Models.Migrations.AccountMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                "dbo.SecurityAccounts",
                c => new
                    {
                        SecurityAccountID = c.Int(nullable: false, identity: true),
                        Answer = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        SecurityQuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SecurityAccountID)
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
                "dbo.UserClaims",
                c => new
                    {
                        ClaimID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ClaimValue = c.String(),
                        ClaimType = c.String(),
                    })
                .PrimaryKey(t => t.ClaimID)
                .ForeignKey("dbo.Credentials", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Email = c.String(),
                        ProfilePicture = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        SkillLevel = c.String(),
                        Description = c.String(),
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
                "dbo.Salts",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        SaltValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Credentials", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.TokenBlackLists",
                c => new
                    {
                        TokenBlackListID = c.Int(nullable: false, identity: true),
                        Tokens = c.String(),
                    })
                .PrimaryKey(t => t.TokenBlackListID);
            
            CreateTable(
                "dbo.TokenLists",
                c => new
                    {
                        TokenListID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Token = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.TokenListID)
                .ForeignKey("dbo.Credentials", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TokenLists", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.Salts", "UserID", "dbo.Credentials");
            
            DropForeignKey("dbo.UserProfiles", "LocationID", "dbo.Locations");
            
            DropForeignKey("dbo.UserProfiles", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.UserClaims", "UserID", "dbo.Credentials");
            DropForeignKey("dbo.SecurityAccounts", "SecurityQuestionID", "dbo.SecurityQuestions");
            DropForeignKey("dbo.SecurityAccounts", "UserID", "dbo.Credentials");
            DropIndex("dbo.TokenLists", new[] { "UserID" });
            DropIndex("dbo.Salts", new[] { "UserID" });
            
            DropIndex("dbo.UserProfiles", new[] { "LocationID" });
            DropIndex("dbo.UserProfiles", new[] { "UserID" });
            
            DropIndex("dbo.UserClaims", new[] { "UserID" });
            DropIndex("dbo.SecurityAccounts", new[] { "SecurityQuestionID" });
            DropIndex("dbo.SecurityAccounts", new[] { "UserID" });
            DropTable("dbo.TokenLists");
            DropTable("dbo.TokenBlackLists");
            DropTable("dbo.Salts");
            
            DropTable("dbo.Locations");
            
            DropTable("dbo.UserProfiles");
           
            DropTable("dbo.UserClaims");
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.SecurityAccounts");
            DropTable("dbo.Credentials");
        }
    }
}
