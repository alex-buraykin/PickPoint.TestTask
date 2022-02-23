using System.Threading.Tasks;
using FluentAssertions;
using PickPoint.TestTask.Storage.Queries;
using PickPoint.TestTask.Storage.Repository;
using PickPoint.TestTask.Storage.Schema.Entities;
using PickPoint.TestTask.Storage.Shared;
using PickPoint.TestTask.Storage.Shared.Enums;
using Xunit;

namespace PickPoint.TestTask.Storage.Tests.Repository;

public class OrderRepositoryTests
{
    private readonly MemoryDbContext _dbContext;
    private readonly OrderRepository _repository;
    
    public OrderRepositoryTests()
    {
        _dbContext = new MemoryDbContext();
        _repository = new OrderRepository(_dbContext);
    }
    
    [Fact]
    public async Task CreateAsync_HappyDayScenario()
    {
        // arrange
        _dbContext.PickUpPoints.Add(new PickUpPoint {Id = "1234-567", Address = "PickUpPointAddress", State = true});
        await _dbContext.SaveChangesAsync();
        var query = new CreateOrderQuery(10.22m, "+7-928-999-99-99", "Иванов Иван Иванович",
            new[] {"Мачете", "Не смс-ит"}, "1234-567");
        var expected = new OrderDto(1, OrderState.Registered, 10.22m, "+7-928-999-99-99", "Иванов Иван Иванович",
            new[] {"Мачете", "Не смс-ит"}, "1234-567");
        
        // act
        var result = await _repository.CreateAsync(query);
        
        // assert
        Assert.NotEmpty(_dbContext.Orders);
        result.Should().BeEquivalentTo(expected, c => c
            .ComparingByMembers<OrderDto>());
    }
}