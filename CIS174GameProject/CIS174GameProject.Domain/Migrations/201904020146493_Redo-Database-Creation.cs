namespace CIS174GameProject.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedoDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                {
                    ErrorId = c.Guid(nullable: false),
                    ErrorDate = c.DateTime(),
                    ErrorMessage = c.String(),
                    StackTrace = c.String(),
                    InnerExceptions = c.String(),
                })
                .PrimaryKey(t => t.ErrorId);

            CreateTable(
                "dbo.HighScores",
                c => new
                {
                    HighscoreId = c.Guid(nullable: false),
                    PersonId = c.Guid(nullable: false),
                    Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                    DateAttained = c.DateTime(),
                })
                .PrimaryKey(t => t.HighscoreId);

            CreateTable(
                "dbo.People",
                c => new
                {
                    PersonId = c.Guid(nullable: false),
                    FirstName = c.String(maxLength: 50),
                    LastName = c.String(maxLength: 50),
                    Gender = c.Int(nullable: false),
                    DateCreated = c.DateTime(),
                    Email = c.String(maxLength: 100),
                    PhoneNumber = c.String(maxLength: 16),
                })
                .PrimaryKey(t => t.PersonId);
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.HighScores");
            DropTable("dbo.Errors");
        }
    }
}
