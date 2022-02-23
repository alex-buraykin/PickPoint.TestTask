using System.Text.Json.Serialization;
using PickPoint.TestTask.Storage.Shared.Enums;

namespace PickPoint.TestTask.WebApi.Models;

public class OrderInfoResponse
{
    /// <summary>
    /// Номер заказа
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Статус заказа
    /// </summary>
    public OrderState State { get; set; }
    
    /// <summary>
    /// Стоимость заказа
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Номер телефона получателя
    /// </summary>
    public string RecipientPhone { get; set; }
    
    /// <summary>
    /// ФИО получателя
    /// </summary>
    public string RecipientFullName { get; set; }
    
    /// <summary>
    /// Состав заказа
    /// </summary>
    public IReadOnlyCollection<string> Products { get; set; }
    
    /// <summary>
    /// Номер постамата доставки
    /// </summary>
    public string PickUpPointId { get; set; }

    [JsonConstructor]
    public OrderInfoResponse()
    {
    }

    public OrderInfoResponse(
        int id, 
        OrderState state, 
        decimal price, 
        string recipientPhone, 
        string recipientFullName, 
        IReadOnlyCollection<string> products, 
        string pickUpPointId)
    {
        Id = id;
        State = state;
        Price = price;
        RecipientPhone = recipientPhone;
        RecipientFullName = recipientFullName;
        Products = products;
        PickUpPointId = pickUpPointId;
    }
}