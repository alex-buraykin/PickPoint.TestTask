using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickPoint.TestTask.Storage.Schema.Entities;

namespace PickPoint.TestTask.Storage.Schema.Configurations;

public class PickUpPointConfiguration : IEntityTypeConfiguration<PickUpPoint>
{
    public void Configure(EntityTypeBuilder<PickUpPoint> builder)
    {
        builder.Property(s => s.Id)
            .HasMaxLength(8);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Address)
            .IsRequired();
    }
}