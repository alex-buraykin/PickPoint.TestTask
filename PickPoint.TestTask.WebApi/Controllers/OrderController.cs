using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickPoint.TestTask.Storage.Repository.Interfaces;
using PickPoint.TestTask.WebApi.Models;
using PickPoint.TestTask.WebApi.Controllers.Translators;

namespace PickPoint.TestTask.WebApi.Controllers;

/// <summary>
/// АПИ работы с заказами
/// </summary>
[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IPickUpPointRepository _pickUpPointRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderController(
        IPickUpPointRepository pickUpPointRepository,
        IOrderRepository orderRepository)
    {
        _pickUpPointRepository = pickUpPointRepository;
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <response code="200">Если заказ успешно создан</response> 
    /// <response code="400">Если запрос не прошел валидацию</response> 
    /// <response code="403">Если запрашиваемый постамат неактивен</response> 
    /// <response code="404">Если запрашиваемый постамат не найден</response> 
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderInfoResponse>> Create(CreateOrderRequest request)
    {
        var pickUpPoint = await _pickUpPointRepository.FindAsync(request.PickUpPointId);
        if (pickUpPoint is null)
            return NotFound();
    
        if (!pickUpPoint.Value.State)
            return Forbid();
    
        var query = request.ToQuery();
        var order = await _orderRepository.CreateAsync(query);
        return Ok(order.ToResponse());
    }

    /// <summary>
    /// Изменение заказа
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Если заказ успешно изменен</response> 
    /// <response code="400">Если запрос не прошел валидацию</response> 
    /// <response code="404">Если заказ не найден</response> 
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderInfoResponse>> Edit(EditOrderRequest request)
    {
        var order = await _orderRepository.EditAsync(request.ToQuery());
        
        return order.HasValue
            ? Ok(order.Value.ToResponse())
            : NotFound();
    }

    /// <summary>
    /// Получение информации о заказе
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Если заказ найден</response> 
    /// <response code="404">Если не найден заказ</response> 
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderInfoResponse>> GetInfo([Required] int id)
    {
        var order = await _orderRepository.FindAsync(id);

        return order.HasValue
            ? Ok(order.Value.ToResponse())
            : NotFound();
    }
    
    /// <summary>
    /// Отмена заказа
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Если заказ отменен</response> 
    /// <response code="404">Если не найден заказ для отмены</response> 
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Cancel([Required] int id)
    {
        var result = await _orderRepository.TryCancelAsync(id);

        return result
            ? Ok()
            : NotFound();
    }
}