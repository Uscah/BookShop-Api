using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.ToTable("OrderStatus");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasData(
            new OrderStatus{ Id = 1, Name = "Pending"},
            new OrderStatus{ Id = 2, Name = "Paid"},
            new OrderStatus{ Id = 3, Name = "Processing"},
            new OrderStatus{ Id = 4, Name = "Shipped"},
            new OrderStatus{ Id = 5, Name = "Delivered"},
            new OrderStatus{ Id = 6, Name = "Cancelled"},
            new OrderStatus{ Id = 7, Name = "Refunded"}
        );
    }
}