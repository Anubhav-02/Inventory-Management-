using Microsoft.EntityFrameworkCore;
using ProductInventoryApi.Models;

namespace ProductInventoryApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
}
