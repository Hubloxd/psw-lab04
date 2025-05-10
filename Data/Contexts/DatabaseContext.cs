using lab04.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lab04.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Event> Events => Set<Models.Event>();
        public DbSet<User> Users => Set<Models.User>();
        public DbSet<Registration> Registrations => Set<Models.Registration>();

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
