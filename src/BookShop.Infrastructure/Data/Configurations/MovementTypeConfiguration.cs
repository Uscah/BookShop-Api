using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>
{
    public void Configure(EntityTypeBuilder<MovementType> builder)
    {
        builder.ToTable("MovementTypes");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasData(
            new MovementType{ Id = 1, Name = "Purchase"},
            new MovementType{ Id = 2, Name = "Sale"},
            new MovementType{ Id = 3, Name = "Adjustment"},
            new MovementType{ Id = 4, Name = "Damage"},
            new MovementType{ Id = 5, Name = "Return"}
        );
    }
}