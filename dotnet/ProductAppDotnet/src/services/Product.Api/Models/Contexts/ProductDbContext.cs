using Microsoft.EntityFrameworkCore;
using Product.Api.Models.Entities;

namespace Product.Api.Models.Contexts
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Entities.Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
        }
    }
}
