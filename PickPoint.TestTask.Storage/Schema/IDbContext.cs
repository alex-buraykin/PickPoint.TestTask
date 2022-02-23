using Microsoft.EntityFrameworkCore;
using PickPoint.TestTask.Storage.Schema.Entities;

namespace PickPoint.TestTask.Storage.Schema;

public interface IDbContext : IDisposable, IAsyncDisposable
{
    DbSet<Order> Orders { get; }
    DbSet<OrderProduct> OrderProducts { get; }
    DbSet<PickUpPoint> PickUpPoints { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}