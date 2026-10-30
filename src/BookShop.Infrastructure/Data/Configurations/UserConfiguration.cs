using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Username)
            .HasMaxLength(32)
            .IsRequired();
        builder.Property(a => a.Email)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(a => a.PasswordHashed)
            .IsRequired()
            .HasMaxLength(256);
        builder.Property(a => a.CreatedAt)
            .IsRequired();
        builder.HasOne(a => a.Role)
            .WithMany(b => b.Users)
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}