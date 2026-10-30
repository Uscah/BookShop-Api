using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class InventoryMovementDetailConfiguration : IEntityTypeConfiguration<InventoryMovementDetail>
{
    public void Configure(EntityTypeBuilder<InventoryMovementDetail> builder)
    {
        builder.ToTable("InventoryMovementDetails");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.InventoryMovement)
            .WithMany(b => b.InventoryMovementDetails)
            .HasForeignKey(a => a.InventoryMovementId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(a => a.BookEdition)
            .WithMany(b => b.InventoryMovementDetails)
            .HasForeignKey(a => a.BookEditionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.Quantity)
            .IsRequired();
        builder.Property(a => a.StockBefore)
            .IsRequired();
        builder.Property(a => a.StockAfter)
            .IsRequired();
    }
}