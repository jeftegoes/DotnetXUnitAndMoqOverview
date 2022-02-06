using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new StoreContext(optionsBuilder.Options);
        }
    }
}