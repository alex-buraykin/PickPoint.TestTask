using System.ComponentModel.DataAnnotations;

namespace PickPoint.TestTask.WebApi.Models;

/// <summary>
/// Запрос создания заказа
/// </summary>
public class CreateOrderRequest : IValidatableObject
{
    /// <summary>
    /// Стоимость заказа
    /// </summary>
    [Required]
    public decimal Price { get; set; }
    
    /// <summary>
    /// Номер телефона получателя в формате +7XXX-XXX-XX-XX
    /// </summary>
    [Required]
    [StringLength(16)]
    [RegularExpression(@"^\+7-\d{3}-\d{3}-\d{2}-\d{2}$")]
    public string RecipientPhone { get; set; }
    
    /// <summary>
    /// ФИО получателя
    /// </summary>
    [Required]
    public string RecipientFullName { get; set; }
    
    /// <summary>
    /// Состав заказа
    /// </summary>
    [Required]
    public IReadOnlyCollection<string> Products { get; set; }
    
    /// <summary>
    /// Номер постамата доставки
    /// </summary>
    [Required]
    [StringLength(8)]
    [RegularExpression(@"^\d{4}-\d{3}$")]
    public string PickUpPointId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Products.Count == 0)
            yield return new ValidationResult("Нет товаров для заказа", new[] {nameof(Products)});
        else if (Products.Count > 10)
            yield return new ValidationResult("Слишком много товаров в заказе (больше 10)", new[] {nameof(Products)});
    }
}