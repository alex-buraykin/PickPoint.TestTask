namespace PickPoint.TestTask.Storage.Queries;

public readonly record struct CreateOrderQuery(
    decimal Price,
    string RecipientPhone,
    string RecipientFullName,
    IReadOnlyCollection<string> Products,
    string PickUpPointId);