using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Models;

namespace ProductInventoryApi.Data;  // Namespace for data access layer

public class AppDbContext : DbContext // Database context for the application
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }  // Constructor with options
    public DbSet<Product> Products => Set<Product>();  // DbSet for products
}
