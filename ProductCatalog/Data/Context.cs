using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataMaps;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
