namespace PickPoint.TestTask.Storage.Schema.Entities;

public class PickUpPoint
{
    public string Id { get; set; }
    public string Address { get; set; }
    public bool State { get; set; }
    
    public List<Order> Orders { get; set; } = new();
}