using PickPoint.TestTask.Storage.Queries;
using PickPoint.TestTask.Storage.Shared;
using PickPoint.TestTask.WebApi.Models;

namespace PickPoint.TestTask.WebApi.Controllers.Translators;

internal static class OrderTranslator
{
    public static CreateOrderQuery ToQuery(this CreateOrderRequest request)
    {
        return new CreateOrderQuery(
            request.Price,
            request.RecipientPhone,
            request.RecipientFullName,
            request.Products,
            request.PickUpPointId);
    }

    public static OrderInfoResponse ToResponse(this OrderDto dto)
    {
        return new OrderInfoResponse(
            id: dto.Id,
            state: dto.State,
            price: dto.Price,
            recipientPhone: dto.RecipientPhone,
            recipientFullName: dto.RecipientFullName,
            products: dto.Products,
            pickUpPointId: dto.PickUpPointId);
    }

    public static EditOrderQuery ToQuery(this EditOrderRequest request)
    {
        return new EditOrderQuery(
            request.Id,
            request.Price,
            request.RecipientPhone,
            request.RecipientFullName,
            request.Products);
    }
}