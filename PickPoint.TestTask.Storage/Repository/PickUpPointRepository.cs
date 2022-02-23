using Microsoft.EntityFrameworkCore;
using PickPoint.TestTask.Storage.Repository.Interfaces;
using PickPoint.TestTask.Storage.Repository.Translators;
using PickPoint.TestTask.Storage.Schema;
using PickPoint.TestTask.Storage.Shared;

namespace PickPoint.TestTask.Storage.Repository;

public class PickUpPointRepository : IPickUpPointRepository
{
    private readonly IDbContext _dbContext;

    public PickUpPointRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyCollection<string>> GetAvailableAsync()
    {
        return await _dbContext.PickUpPoints
            .AsNoTracking()
            .Where(s => s.State)
            .OrderBy(s => s.Id)
            .Select(s => s.Id)
            .ToArrayAsync();
    }

    public async Task<PickUpPointDto?> FindAsync(string id)
    {
        var entity = await _dbContext.PickUpPoints
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        return entity?.ToDto();
    }
}