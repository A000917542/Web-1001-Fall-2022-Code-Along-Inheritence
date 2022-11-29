using Microsoft.EntityFrameworkCore;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public string CurrentUser { get; set; } = string.Empty;

        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasMany<ShoppingCart>(p => p.ShoppingCarts).WithMany(sc => sc.Products);
            // builder.Entity<ShoppingCart>().HasMany<Product>(sc => sc.Products).WithMany();
            builder.Entity<User>().HasQueryFilter( u => u.Email == CurrentUser );
            builder.Entity<ShoppingCart>().HasQueryFilter(u => u.Email == CurrentUser && u.User.Email == CurrentUser);


            builder.Entity<User>().HasData(new List<User>() {
            
                new User() { Address = "Address 1", Email = "example@example.com", Name = "Example 1" }
                , new User() { Address = "Address 2", Email = "example2@example.com", Name = "Example 2" }

            });

            builder.Entity<Product>().HasData(new List<Product>() {

                new Product() { Id = Guid.NewGuid(), Name = "Test 1", Price = 2.00M, Description = ""}
                , new Product() { Id = Guid.NewGuid(), Name = "Test 2", Price = 3.00M, Description = ""}
                , new Product() { Id = Guid.NewGuid(), Name = "Test 2", Price = 1.00M, Description = ""}
                , new Product() { Id = Guid.NewGuid(), Name = "Test 2", Price = 7.00M, Description = ""}

            });
        }
    }
}
