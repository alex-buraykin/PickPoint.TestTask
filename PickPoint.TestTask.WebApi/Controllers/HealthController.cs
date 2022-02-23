using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickPoint.TestTask.WebApi.Models;

namespace PickPoint.TestTask.WebApi.Controllers;

/// <summary>
/// АПИ для пуллинга доступности сервиса
/// </summary>
[AllowAnonymous]
[ApiController]
public class HealthController : Controller
{
    private static readonly HealthCheckResponse HealthCheckResponse = new("I'm alive!");

    /// <summary>
    /// Возвращает сообщение о том, что сервис жив.
    /// </summary>
    [HttpGet]
    [Route("Health")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<HealthCheckResponse> HealthCheck()
    {
        return Ok(HealthCheckResponse);
    }

    /// <summary>
    /// Возвращает сообщение о версии сервиса.
    /// </summary>
    [HttpGet]
    [Route("Version")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<VersionResponse> Version()
    {
        var assembly = Assembly.GetAssembly(typeof(HealthController));
            
        var assemblyVersion = assembly?.GetName().Version?.ToString();
        var assemblyFileVersion = assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>();
        var assemblyInformationalVersion = assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

        var response = new VersionResponse
        {
            AssemblyVersion = assemblyVersion,
            AssemblyFileVersion = assemblyFileVersion?.Version,
            AssemblyInformationalVersion = assemblyInformationalVersion?.InformationalVersion,
        };

        return Ok(response);
    }
}