using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace PetStore.Data
{
    public class ProductContext : DbContext
    {
        // DbSet for ProductEntity
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<DogLeash> DogLeashes { get; set; }
        public DbSet<CatFood> CatFoods { get; set; }


        // Configure the SQLite connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=petstore.db");
        }

        // Configure model properties (e.g., keys, table names)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.HasKey(e => e.ProductId); // Set ProductId as the primary key
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100); // Example: Name is required with max length
                // Add other entity configurations here if needed
            });
        }
    }
}
