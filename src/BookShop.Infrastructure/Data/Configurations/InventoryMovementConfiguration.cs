using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.ToTable("InventoryMovements");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.User)
            .WithMany(b => b.InventoryMovements)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(a => a.MovementType)
            .WithMany(b => b.InventoryMovements)
            .HasForeignKey(a => a.MovementTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(a => a.Order)
            .WithMany(b => b.InventoryMovements)
            .HasForeignKey(a => a.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(a => a.CreatedAt)
            .IsRequired();
    }
}