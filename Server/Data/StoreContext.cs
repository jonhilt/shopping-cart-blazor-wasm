using Microsoft.EntityFrameworkCore;
using ShoppingCartStarter.Server.DomainModels;

namespace ShoppingCartStarter.Server.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ShoppingCart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ShoppingCart>()
                .HasMany(x => x.LineItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}