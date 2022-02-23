namespace PickPoint.TestTask.Storage.Shared;

public readonly record struct PickUpPointDto(
    string Id, 
    string Address, 
    bool State);