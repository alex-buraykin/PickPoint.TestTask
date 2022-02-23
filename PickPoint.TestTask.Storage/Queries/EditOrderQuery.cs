namespace PickPoint.TestTask.Storage.Queries;

public readonly record struct EditOrderQuery(
    int Id, 
    decimal? Price,
    string? RecipientPhone,
    string? RecipientFullName,
    IReadOnlyCollection<string>? Products);