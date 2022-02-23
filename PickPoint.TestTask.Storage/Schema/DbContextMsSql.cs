using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PickPoint.TestTask.Storage.Schema.Configurations;
using PickPoint.TestTask.Storage.Schema.Entities;

namespace PickPoint.TestTask.Storage.Schema;

public class DbContextMsSql : DbContext, IDbContext
{
    private const string SchemaName = "pp";
    
    private readonly IConfiguration _configuration;
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<PickUpPoint> PickUpPoints { get; set; }
    
    public DbContextMsSql(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);

        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
        modelBuilder.ApplyConfiguration(new PickUpPointConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = _configuration.GetConnectionString("PickPointDb");
        
        options.UseSqlServer(connectionString);
    }
}