using CIS174GameProject.Domain.Entities;
using System.Data.Entity;

namespace CIS174GameProject.Domain
{
    public class ProjectContext : DbContext
    {
        public DbSet<HighScore> Highscores { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
