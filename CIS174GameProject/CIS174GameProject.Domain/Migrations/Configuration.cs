namespace CIS174GameProject.Domain.Migrations
{
    using CIS174GameProject.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CIS174GameProject.Domain.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CIS174GameProject.Domain.ProjectContext context)
        {
            context.Errors.AddOrUpdate(new Error
            {
                ErrorId = Guid.Parse("4b8836cb-d3e7-4b29-b391-515ba99505e2"),
                ErrorDate = DateTime.Now,
                ErrorMessage = "Example Error Message",
                StackTrace = "Example Stack Trace",
                InnerExceptions = "Example Inner Exceptions"
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                FirstName = "Benjamin",
                LastName = "Frederickson",
                Gender = 0,
                DateCreated = DateTime.Now,
                Email = "bfrederickson@dmacc.edu",
                PhoneNumber = ""
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"),
                FirstName = "Jared",
                LastName = "Holliday",
                Gender = 0,
                DateCreated = DateTime.Now,
                Email = "jrholliday@dmacc.edu",
                PhoneNumber = ""
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"),
                FirstName = "Ian",
                LastName = "Tibe",
                Gender = 0,
                DateCreated = DateTime.Now,
                Email = "imtibe@dmacc.edu",
                PhoneNumber = ""
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighscoreId = Guid.Parse("ebeaa736-2a57-4112-92a6-9cab67845010"),
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                Score = 1000,
                DateAttained = DateTime.Now
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighscoreId = Guid.Parse("71a62a7d-68c7-4963-a3d4-491af3e2f63c"),
                PersonId = Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"),
                Score = 500,
                DateAttained = DateTime.Now
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighscoreId = Guid.Parse("85837194-aab8-4866-8189-ccf6d001781d"),
                PersonId = Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"),
                Score = 200,
                DateAttained = DateTime.Now
            });
        }
    }
}
