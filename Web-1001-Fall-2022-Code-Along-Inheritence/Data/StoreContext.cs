using Microsoft.EntityFrameworkCore;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasMany<ShoppingCart>(p => p.ShoppingCarts).WithMany(sc => sc.Products);
            // builder.Entity<ShoppingCart>().HasMany<Product>(sc => sc.Products).WithMany();
        }
    }
}
