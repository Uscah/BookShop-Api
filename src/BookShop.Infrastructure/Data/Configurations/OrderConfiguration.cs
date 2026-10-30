using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.PublicId)
            .IsRequired()
            .HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.HasIndex(a => a.PublicId)
            .IsUnique();
        builder.HasOne(a => a.User)
            .WithMany(b => b.Orders)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.TotalAmount)
            .HasPrecision(18, 2)
            .IsRequired();
        builder.HasOne(a => a.PaymentProvider)
            .WithMany(b => b.Orders)
            .HasForeignKey(a => a.PaymentProviderId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.PaymentIdReference)
            .HasMaxLength(32)
            .IsRequired();
        builder.Property(a => a.Address)
            .HasMaxLength(52)
            .IsRequired();
        builder.HasOne(a => a.OrderStatus)
            .WithMany(b => b.Orders)
            .HasForeignKey(a => a.OrderStatusId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.CreatedAt)
            .IsRequired();
    }
}