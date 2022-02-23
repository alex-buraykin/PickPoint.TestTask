using Newtonsoft.Json;

namespace PickPoint.TestTask.WebApi.Models;

/// <summary>
/// Статус доступности сервиса
/// </summary>
public class HealthCheckResponse
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string? Message { get; set; }
    
    [JsonConstructor]
    public HealthCheckResponse()
    {
    }
    
    public HealthCheckResponse(string message)
    {
        Message = message;
    }
}