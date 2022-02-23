namespace PickPoint.TestTask.Storage.Schema.Entities;

public class OrderProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Order Order { get; set; }
    public int OrderId { get; set; }
}