using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ProductsAPI.Models
{
    public class ProductsContext:IdentityDbContext<AppUser,AppRole, int>
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options): base(options) 
        {
        
        }


        //Creating Dummy Data

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Product>().HasData(new Product (){ ProductId = 1, ProductName = "IPhone 14", Price = 60000, IsActive = true });
        //    modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 2, ProductName = "IPhone 15", Price = 60000, IsActive = true });
        //    modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 3, ProductName = "IPhone 16", Price = 60000, IsActive = false });
        //    modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 4, ProductName = "IPhone 17", Price = 60000, IsActive = true });
        //    modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 5, ProductName = "IPhone 18", Price = 60000, IsActive = true });
        //}
    }
}
