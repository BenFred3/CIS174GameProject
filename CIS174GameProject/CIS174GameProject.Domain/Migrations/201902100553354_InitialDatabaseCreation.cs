namespace CIS174GameProject.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HighScores",
                c => new
                    {
                        HighSchoolId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAttained = c.DateTime(),
                    })
                .PrimaryKey(t => t.HighSchoolId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        DateCreated = c.DateTime(),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.HighScores");
        }
    }
}
