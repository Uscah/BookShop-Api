using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(a => a.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(a => a.BookEdition)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(a => a.BookEditionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.Quantity)
            .IsRequired();
        builder.Property(a => a.Price)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}