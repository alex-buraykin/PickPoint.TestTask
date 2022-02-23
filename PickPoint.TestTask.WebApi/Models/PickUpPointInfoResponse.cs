using Newtonsoft.Json;

namespace PickPoint.TestTask.WebApi.Models;

/// <summary>
/// Информация о постамате
/// </summary>
public class PickUpPointInfoResponse
{
    /// <summary>
    /// Номер
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Статус постамата
    ///     <value>true</value> - рабочий
    ///     <value>false</value> - закрыт
    /// </summary>
    public bool State { get; set; }

    [JsonConstructor]
    public PickUpPointInfoResponse()
    {
    }

    public PickUpPointInfoResponse(
        string id, 
        string address, 
        bool state)
    {
        Id = id;
        Address = address;
        State = state;
    }
}