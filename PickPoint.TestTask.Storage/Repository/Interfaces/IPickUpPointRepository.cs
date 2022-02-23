using PickPoint.TestTask.Storage.Shared;

namespace PickPoint.TestTask.Storage.Repository.Interfaces;

public interface IPickUpPointRepository
{
    Task<IReadOnlyCollection<PickUpPointDto>> GetAvailableAsync();
    Task<PickUpPointDto?> FindAsync(string id);
}