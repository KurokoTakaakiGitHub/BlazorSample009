using BlazorSample009.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorSample009.Server
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity
                .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired();

                entity.Property(e => e.Price)
                .HasColumnName("Price")
                .IsRequired();

            });

            
            //modelBuilder.Entity<Product>().HasData(
            //    new Product(){ Id = "001", Name = "Book", Price = 1000 },
            //    new Product() { Id = "002", Name = "Pen", Price = 500 },
            //    new Product() { Id = "003", Name = "Laptop", Price = 30000 }
            //    );

            base.OnModelCreating(modelBuilder);
        }
    }
}