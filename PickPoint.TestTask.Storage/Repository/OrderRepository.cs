using Microsoft.EntityFrameworkCore;
using PickPoint.TestTask.Storage.Queries;
using PickPoint.TestTask.Storage.Repository.Interfaces;
using PickPoint.TestTask.Storage.Repository.Translators;
using PickPoint.TestTask.Storage.Schema;
using PickPoint.TestTask.Storage.Schema.Entities;
using PickPoint.TestTask.Storage.Shared;
using PickPoint.TestTask.Storage.Shared.Enums;

namespace PickPoint.TestTask.Storage.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly IDbContext _dbContext;

    public OrderRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<OrderDto> CreateAsync(CreateOrderQuery query)
    {
        var entity = _dbContext.Orders.Add(query.ToEntity()).Entity;

        await _dbContext.SaveChangesAsync();

        return entity.ToDto();
    }

    public async Task<OrderDto?> EditAsync(EditOrderQuery query)
    {
        var entity = await _dbContext.Orders
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == query.Id);
        if (entity is null)
            return null;

        if (query.Price.HasValue)
            entity.Price = query.Price.Value;
        if (query.RecipientPhone is not null)
            entity.RecipientPhone = query.RecipientPhone;
        if (query.RecipientFullName is not null)
            entity.RecipientFullName = query.RecipientFullName;
        if (query.Products is not null)
            entity.Products = query.Products.Select(s => new OrderProduct {Name = s}).ToList();
        
        await _dbContext.SaveChangesAsync();
        return entity.ToDto();
    }

    public async Task<OrderDto?> FindAsync(int id)
    {
        var entity = await _dbContext.Orders
            .AsNoTracking()
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == id);

        return entity?.ToDto();
    }

    public async Task<bool> TryCancelAsync(int id)
    {
        var entity = await _dbContext.Orders
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (entity is null)
            return false;

        entity.State = OrderState.Cancelled;
        await _dbContext.SaveChangesAsync();
        return true;
    }
}