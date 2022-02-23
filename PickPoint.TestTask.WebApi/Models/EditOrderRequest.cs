using System.ComponentModel.DataAnnotations;

namespace PickPoint.TestTask.WebApi.Models;

/// <summary>
/// Запрос изменения заказа
/// </summary>
public class EditOrderRequest : IValidatableObject
{
    /// <summary>
    /// Номер заказа
    /// </summary>
    [Required]
    public int Id { get; set; }
    
    /// <summary>
    /// Стоимость заказа
    /// </summary>
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Номер телефона получателя
    /// </summary>
    [StringLength(16)]
    [RegularExpression(@"^\+7-\d{3}-\d{3}-\d{2}-\d{2}$")]
    public string? RecipientPhone { get; set; }
    
    /// <summary>
    /// ФИО получателя
    /// </summary>
    public string? RecipientFullName { get; set; }
    
    /// <summary>
    /// Состав заказа
    /// </summary>
    public IReadOnlyCollection<string>? Products { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Products != null)
        {
            if (Products.Count == 0)
                yield return new ValidationResult("Нет товаров для заказа", new[] {nameof(Products)});
            else if (Products.Count > 10)
                yield return new ValidationResult("Слишком много товаров в заказе (больше 10)", new[] {nameof(Products)});

        }
    }
}