using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickPoint.TestTask.Storage.Schema.Entities;

namespace PickPoint.TestTask.Storage.Schema.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.RecipientPhone)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(s => s.RecipientFullName)
            .IsRequired();

        builder.HasMany(s => s.Products)
            .WithOne(s => s.Order)
            .HasForeignKey(s => s.OrderId);
        
        builder.HasOne(s => s.PickUpPoint)
            .WithMany(s => s.Orders)
            .HasForeignKey(s => s.PickUpPointId);
    }
}