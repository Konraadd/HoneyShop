using Microsoft.EntityFrameworkCore;

namespace HoneyShop.Entities
{
    public class HoneyShopDbContext : DbContext
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb; Database=HoneyShopDb; Trusted_Connection=True";
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(12, 2);
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();
        }
    }

}
