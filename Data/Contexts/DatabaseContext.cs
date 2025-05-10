using Microsoft.EntityFrameworkCore;

namespace lab04.Data.Contexts
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Models.Event> Events => Set<Models.Event>();
        public DbSet<Models.User> Users => Set<Models.User>();
        public DbSet<Models.Registration> Registrations => Set<Models.Registration>();

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
