namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecurityQandA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecurityAnswers",
                c => new
                    {
                        SecurityQuestionID = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        UserID = c.Int(nullable: false),
                        Question = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SecurityQuestionID)
                .ForeignKey("dbo.SecurityQuestions", t => t.Question)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.Question);
            
            CreateTable(
                "dbo.SecurityQuestions",
                c => new
                    {
                        Questions = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Questions);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityAnswers", "UserID", "dbo.Users");
            DropForeignKey("dbo.SecurityAnswers", "Question", "dbo.SecurityQuestions");
            DropIndex("dbo.SecurityAnswers", new[] { "Question" });
            DropIndex("dbo.SecurityAnswers", new[] { "UserID" });
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.SecurityAnswers");
        }
    }
}
