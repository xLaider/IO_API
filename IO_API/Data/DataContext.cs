using IO_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IO_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<World> Worlds { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }
}
