using IO_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IO_API.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BigField> BigFields { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UsersProgressInfo> UsersProgressInfo { get; set; }
        public DbSet<World> Worlds { get; set; }
        public DbSet<BuildingsShop> BuildingsShop { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
