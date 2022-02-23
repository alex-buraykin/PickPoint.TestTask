using PickPoint.TestTask.Storage.Queries;
using PickPoint.TestTask.Storage.Shared;

namespace PickPoint.TestTask.Storage.Repository.Interfaces;

public interface IOrderRepository
{
    Task<OrderDto> CreateAsync(CreateOrderQuery query);
    Task<OrderDto> EditAsync(EditOrderQuery query);
    Task<OrderDto?> FindAsync(int id);
    Task DeleteAsync(int id);
}