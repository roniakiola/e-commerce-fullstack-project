using Domain.Entity;
using Microsoft.EntityFrameworkCore;
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

    static DatabaseContext()
    {
      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
      AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("ECommerceDB"));
      optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
      optionsBuilder.AddInterceptors(new TimeStampInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
        .HasOne(u => u.UserContactDetails)
        .WithOne(uc => uc.User)
        .HasForeignKey<UserContactDetails>(uc => uc.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Orders)
        .WithOne(o => o.User)
        .HasForeignKey(o => o.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<User>()
        .HasOne(u => u.Cart)
        .WithOne(c => c.User)
        .HasForeignKey<Cart>(c => c.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<User>()
        .Property(u => u.Role)
        .HasConversion<string>();

      modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

      modelBuilder.Entity<User>()
        .HasIndex(u => u.Username)
        .IsUnique();

      modelBuilder.Entity<Product>()
        .HasMany(p => p.CartItems)
        .WithOne(ci => ci.Product)
        .HasForeignKey(ci => ci.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Product>()
        .HasMany(p => p.OrderItems)
        .WithOne(oi => oi.Product)
        .HasForeignKey(oi => oi.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Product>()
        .HasIndex(p => p.Name)
        .IsUnique();

      modelBuilder.Entity<Category>()
        .HasMany(c => c.Products)
        .WithOne(p => p.Category)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Category>()
        .HasIndex(c => c.Name)
        .IsUnique();

      modelBuilder.Entity<Cart>()
        .HasMany(c => c.CartItems)
        .WithOne(ci => ci.Cart)
        .HasForeignKey(ci => ci.CartId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order)
        .HasForeignKey(oi => oi.OrderId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Order>()
        .Property(o => o.Status)
        .HasConversion<string>();
    }
  }
}