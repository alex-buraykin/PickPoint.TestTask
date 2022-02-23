using JetBrains.Annotations;
using PickPoint.TestTask.Storage.Schema.Entities;
using PickPoint.TestTask.Storage.Shared;

namespace PickPoint.TestTask.Storage.Repository.Translators;

public static class PickUpPointTranslator
{
    [ContractAnnotation("entity:null => halt")]
    public static PickUpPointDto ToDto(this PickUpPoint entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        return new PickUpPointDto(
            entity.Id, 
            entity.Address,
            entity.State);
    }
}