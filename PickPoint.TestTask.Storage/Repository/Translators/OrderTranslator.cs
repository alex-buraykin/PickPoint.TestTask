using JetBrains.Annotations;
using PickPoint.TestTask.Storage.Queries;
using PickPoint.TestTask.Storage.Schema.Entities;
using PickPoint.TestTask.Storage.Shared;
using PickPoint.TestTask.Storage.Shared.Enums;

namespace PickPoint.TestTask.Storage.Repository.Translators;

public static class OrderTranslator
{
    public static Order ToEntity(this CreateOrderQuery query)
    {
        return new Order
        {
            State = OrderState.Registered,
            Price = query.Price,
            RecipientPhone = query.RecipientPhone,
            RecipientFullName = query.RecipientFullName,
            Products = new List<OrderProduct>(query.Products
                .Select(s => new OrderProduct
                {
                    Name = s
                }).ToArray()),
            PickUpPointId = query.PickUpPointId,
        };
    }
    
    [ContractAnnotation("entity:null => halt")]
    public static OrderDto ToDto(this Order entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        return new OrderDto(
            entity.Id, 
            entity.State,
            entity.Price,
            entity.RecipientPhone,
            entity.RecipientFullName,
            entity.Products.Select(s => s.Name).ToArray(),
            entity.PickUpPointId);
    }
}