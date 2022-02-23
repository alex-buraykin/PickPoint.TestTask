namespace PickPoint.TestTask.Storage.Shared.Enums;

public enum OrderState
{
    Unknown = 0,
    /// <summary>
    /// Зарегистрирован
    /// </summary>
    Registered = 1,
    /// <summary>
    /// Принят на складе
    /// </summary>
    WarehouseAccepted = 2,
    /// <summary>
    /// Принят на складе
    /// </summary>
    CourierAccepted = 3,
    /// <summary>
    /// Доставлен в постамат
    /// </summary>
    DeliveredToPost = 4,
    /// <summary>
    /// Доставлен в постамат
    /// </summary>
    DeliveredToRecipient = 5,
    /// <summary>
    /// Отменен
    /// </summary>
    Cancelled = 6
}