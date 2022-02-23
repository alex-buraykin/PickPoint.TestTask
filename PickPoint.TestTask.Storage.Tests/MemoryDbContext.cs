using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PickPoint.TestTask.Storage.Schema;

namespace PickPoint.TestTask.Storage.Tests;

public class MemoryDbContext : DbContextMsSql
{
    public MemoryDbContext() : base(null!)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase($"PickPointDb_{Guid.NewGuid().ToString()}");
    }
		
    public override ValueTask DisposeAsync()
    {
        // do not dispose
        return ValueTask.CompletedTask;
    }

    public override void Dispose()
    {
        // do not dispose
    }
}