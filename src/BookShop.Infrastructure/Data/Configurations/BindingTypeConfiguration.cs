using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class BindingTypeConfiguration : IEntityTypeConfiguration<BindingType>
{
    public void Configure(EntityTypeBuilder<BindingType> builder)
    {
        builder.ToTable("BindingTypes");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.HasData(
            new BindingType{ Id = 1, Name = "SoftCover" },
            new BindingType{ Id = 2, Name = "HardCover"},
            new BindingType{ Id = 3, Name = "AudioBook"},
            new BindingType{ Id = 4, Name = "DigitalBook"}
        );
    }
}