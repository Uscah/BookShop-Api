using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class PaymentProviderConfiguration : IEntityTypeConfiguration<PaymentProvider>
{
    public void Configure(EntityTypeBuilder<PaymentProvider> builder)
    {
        builder.ToTable("PaymentProviders");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder.HasData(
            new PaymentProvider{ Id = 1, Name = "Stripe"},
            new PaymentProvider{ Id = 2, Name = "PayPal"},
            new PaymentProvider{ Id = 3, Name = "Cash"},
            new PaymentProvider{ Id = 4, Name = "POS"}
        );
    }
}