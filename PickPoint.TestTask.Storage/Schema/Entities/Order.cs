using PickPoint.TestTask.Storage.Shared.Enums;

namespace PickPoint.TestTask.Storage.Schema.Entities;

public class Order
{
    public int Id { get; set; }
    public OrderState State { get; set; }
    public decimal Price { get; set; }
    public string RecipientPhone { get; set; }
    public string RecipientFullName { get; set; }
    
    public List<OrderProduct> Products { get; set; } = new();
    public PickUpPoint PickUpPoint { get; set; }
    public string PickUpPointId { get; set; }
}