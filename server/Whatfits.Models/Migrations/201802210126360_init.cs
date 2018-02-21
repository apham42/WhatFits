namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chatrooms",
                c => new
                    {
                        ChatroomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.String(),
                    })
                .PrimaryKey(t => t.ChatroomID);
            
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
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Title = c.String(),
                        CreatedAt = c.String(),
                        DateTime = c.String(),
                        Description = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FollowingPerson = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowerID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PersonFollowing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FollowingID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ChatroomID = c.Int(nullable: false),
                        MessageContent = c.String(),
                        CreatedAt = c.String(),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Chatrooms", t => t.ChatroomID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ChatroomID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewerID = c.Int(nullable: false),
                        RevieweeID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        ReviewMessage = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Users", t => t.ReviewerID, cascadeDelete: true)
                .Index(t => t.ReviewerID);
            
            CreateTable(
                "dbo.WorkoutLogs",
                c => new
                    {
                        WorkoutLogID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        WorkoutType = c.String(),
                        Date_Time = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutLogID)
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
                        WorkoutLog_WorkoutLogID = c.Int(),
                    })
                .PrimaryKey(t => t.CardioID)
                .ForeignKey("dbo.WorkoutLogs", t => t.WorkoutLog_WorkoutLogID)
                .Index(t => t.WorkoutLog_WorkoutLogID);
            
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
            DropForeignKey("dbo.WeightLiftings", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.WorkoutLogs", "UserID", "dbo.Users");
            DropForeignKey("dbo.Cardios", "WorkoutLog_WorkoutLogID", "dbo.WorkoutLogs");
            DropForeignKey("dbo.Reviews", "ReviewerID", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatroomID", "dbo.Chatrooms");
            DropForeignKey("dbo.Followings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Followers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropIndex("dbo.SecurityAnswers", new[] { "SecurityQuestionID" });
            DropIndex("dbo.SecurityAnswers", new[] { "UserID" });
            DropIndex("dbo.PersonalKeys", new[] { "UserID" });
            DropIndex("dbo.Locations", new[] { "UserID" });
            DropIndex("dbo.WeightLiftings", new[] { "WorkoutLog_WorkoutLogID" });
            DropIndex("dbo.Cardios", new[] { "WorkoutLog_WorkoutLogID" });
            DropIndex("dbo.WorkoutLogs", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "ReviewerID" });
            DropIndex("dbo.Messages", new[] { "ChatroomID" });
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropIndex("dbo.Followings", new[] { "UserID" });
            DropIndex("dbo.Followers", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Credentials", new[] { "UserID" });
            DropIndex("dbo.Claims", new[] { "UserID" });
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.SecurityAnswers");
            DropTable("dbo.PersonalKeys");
            DropTable("dbo.Locations");
            DropTable("dbo.WeightLiftings");
            DropTable("dbo.Cardios");
            DropTable("dbo.WorkoutLogs");
            DropTable("dbo.Reviews");
            DropTable("dbo.Messages");
            DropTable("dbo.Followings");
            DropTable("dbo.Followers");
            DropTable("dbo.Events");
            DropTable("dbo.Users");
            DropTable("dbo.Credentials");
            DropTable("dbo.Claims");
            DropTable("dbo.Chatrooms");
        }
    }
}
