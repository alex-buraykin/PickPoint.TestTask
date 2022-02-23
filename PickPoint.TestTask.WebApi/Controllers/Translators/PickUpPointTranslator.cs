using PickPoint.TestTask.Storage.Shared;
using PickPoint.TestTask.WebApi.Models;

namespace PickPoint.TestTask.WebApi.Controllers.Translators;

internal static class PickUpPointTranslator
{
    public static PickUpPointInfoResponse ToResponse(this PickUpPointDto dto)
    {
        return new PickUpPointInfoResponse(
            id: dto.Id,
            address: dto.Address,
            state: dto.State);
    }
}