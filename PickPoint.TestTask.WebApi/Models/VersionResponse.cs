using Newtonsoft.Json;

namespace PickPoint.TestTask.WebApi.Models;

/// <summary>
/// Версия сервиса
/// </summary>
public class VersionResponse
{
    /// <summary>
    /// Версия сборки
    /// </summary>
    public string? AssemblyVersion { get; set; }
    
    /// <summary>
    /// Версия файла сборки
    /// </summary>
    public string? AssemblyFileVersion { get; set; }
    
    /// <summary>
    /// Версия из конфигурации сборки
    /// </summary>
    public string? AssemblyInformationalVersion { get; set; }
    
    [JsonConstructor]
    public VersionResponse()
    {
    }

    public VersionResponse(
        string assemblyVersion, 
        string assemblyFileVersion, 
        string assemblyInformationalVersion)
    {
        AssemblyVersion = assemblyVersion;
        AssemblyFileVersion = assemblyFileVersion;
        AssemblyInformationalVersion = assemblyInformationalVersion;
    }
}