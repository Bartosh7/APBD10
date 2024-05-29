using System.ComponentModel;
using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Role> Roles { set; get; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Category> Categories  { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new Role
            {
                RoleId = 1,
                RoleName = "Pachołek"
            }
        });

        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Product 1",
                ProductWeight = 1.12m,
                ProductWidth = 2.45m,
                ProductHeight = 3.23m,
                ProductDepth = 4
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>
        {
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 1,
                ShoppingCartAmount = 24
            }
        });
        
        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                AccountId = 1,
                AccountFirstName = "Jan",
                AccountLastName = "Don",
                AccountEmail = "jandon@gmai.com",
                AccountPhone = "012345678",
                RoleId = 1
            }
        });

        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                CategoryID = 1,
                CategoryName = "Grzechotka"
            },
            new Category
            {
                CategoryID = 2,
                CategoryName = "Flet"
            }
        });
        
        
        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.AccountId, sc.ProductId });
        
        
        
        modelBuilder.Entity<ProductCategory>()
            .HasKey(sc => new {sc.ProductId, sc.CategoryId});
        
        modelBuilder.Entity<Product>()
            .Property(p => p.ProductId)
            .ValueGeneratedOnAdd();

        
    }
}