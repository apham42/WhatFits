namespace Whatfits.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Security : DbMigration
    {
        public override void Up()
        {
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
            
            DropColumn("dbo.Credentials", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credentials", "Role", c => c.String());
            DropForeignKey("dbo.SecurityAnswers", "UserID", "dbo.Users");
            DropForeignKey("dbo.SecurityAnswers", "SecurityQuestionID", "dbo.SecurityQuestions");
            DropIndex("dbo.SecurityAnswers", new[] { "SecurityQuestionID" });
            DropIndex("dbo.SecurityAnswers", new[] { "UserID" });
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.SecurityAnswers");
        }
    }
}
