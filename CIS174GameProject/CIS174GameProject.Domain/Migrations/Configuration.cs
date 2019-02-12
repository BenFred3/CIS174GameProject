namespace CIS174GameProject.Domain.Migrations
{
    using CIS174GameProject.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CIS174GameProject.Domain.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CIS174GameProject.Domain.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                FirstName = "Benjamin",
                LastName = "Frederickson",
                DateCreated = DateTime.Now,
                Email = "bfrederickson@dmacc.edu"
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("2dfafb6c-6ce3-44e2-b41d-6bffcad912a9"),
                FirstName = "Jared",
                LastName = "Holliday",
                DateCreated = DateTime.Now,
                Email = "jrholliday@dmacc.edu"
            });

            context.People.AddOrUpdate(new Person
            {
                PersonId = Guid.Parse("218d38cd-ecfc-43dd-b844-934f701af254"),
                FirstName = "Ian",
                LastName = "Tibe",
                DateCreated = DateTime.Now,
                Email = "imtibe@dmacc.edu"
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighSchoolId = Guid.Parse("ebeaa736-2a57-4112-92a6-9cab67845010"),
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                Score = 1000,
                DateAttained = DateTime.Now
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighSchoolId = Guid.Parse("71a62a7d-68c7-4963-a3d4-491af3e2f63c"),
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                Score = 500,
                DateAttained = DateTime.Now
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighSchoolId = Guid.Parse("85837194-aab8-4866-8189-ccf6d001781d"),
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                Score = 200,
                DateAttained = DateTime.Now
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighSchoolId = Guid.Parse("090d47f8-1718-49c8-b4c8-a220c76b3b09"),
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                Score = 100,
                DateAttained = DateTime.Now
            });

            context.Highscores.AddOrUpdate(new HighScore()
            {
                HighSchoolId = Guid.Parse("da230f13-ddcf-40eb-ae58-20a1266711b2"),
                PersonId = Guid.Parse("52fc5dd8-c147-4fbc-82e6-465fd09b01a3"),
                Score = 50,
                DateAttained = DateTime.Now
            });
        }
    }
}
