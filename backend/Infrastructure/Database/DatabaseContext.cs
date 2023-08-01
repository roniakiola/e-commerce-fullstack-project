using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Database
{
  public class DatabaseContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<User> Users { get; set; }
    public DbSet<UserContactDetails> UserContactDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DatabaseContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("ECommerceDB"));
      optionsBuilder.UseNpgsql(builder.Build());
    }
  }
}