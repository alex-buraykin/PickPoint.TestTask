using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickPoint.TestTask.Storage.Repository.Interfaces;
using PickPoint.TestTask.WebApi.Controllers.Translators;
using PickPoint.TestTask.WebApi.Models;

namespace PickPoint.TestTask.WebApi.Controllers;

/// <summary>
/// АПИ управления постаматами
/// </summary>
[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class PickUpPointController : Controller
{
    private readonly IPickUpPointRepository _pickUpPointRepository;

    public PickUpPointController(
        IPickUpPointRepository pickUpPointRepository)
    {
        _pickUpPointRepository = pickUpPointRepository;
    }

    /// <summary>
    /// Получение списка рабочих постаматов, отсортированных по номеру в алфавитном порядке
    /// </summary>
    /// <returns>Список номеров постаматов</returns>
    /// <response code="200">В случае успеха</response> 
    [HttpGet("Available")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<string>>> GetAvailable()
    {
        var availablePickUpPoints = await _pickUpPointRepository.GetAvailableAsync();
        return Ok(availablePickUpPoints);
    }
    
    /// <summary>
    /// Получение информации о постамате
    /// </summary>
    /// <returns>Информация о постамате</returns>
    /// <response code="200">Если есть информация о постамате</response> 
    /// <response code="404">Если нет информации о постамате</response> 
    /// <response code="400">Если передан номер постамата не в формате XXXX-XXX, гдк Х - цифры</response> 
    [HttpGet]
    [Route("Info/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PickUpPointInfoResponse>> Find(
        [Required] [StringLength(8)] [RegularExpression(@"^\d{4}-\d{3}$")] string id)
    {
        var pickUpPoint = await _pickUpPointRepository.FindAsync(id);
        return pickUpPoint.HasValue ? Ok(pickUpPoint.Value.ToResponse()) : NotFound();
    }
}