using PickPoint.TestTask.Storage.Shared.Enums;

namespace PickPoint.TestTask.Storage.Shared;

public readonly record struct OrderDto(
    int Id, 
    OrderState State, 
    decimal Price,
    string RecipientPhone,
    string RecipientFullName,
    IReadOnlyCollection<string> Products,
    string PickUpPointId);