using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasData(
            new Role{ Id = 1, Name = "Customer"},
            new Role{ Id = 2, Name = "Sales"},
            new Role{ Id = 3, Name = "Inventory"},
            new Role{ Id = 4, Name = "Admin"}
        );
    }
}