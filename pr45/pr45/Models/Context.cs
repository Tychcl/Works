using Microsoft.EntityFrameworkCore;

namespace pr45.Models
{
    public class Context : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.Users> Users { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<Literature> Literature { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
