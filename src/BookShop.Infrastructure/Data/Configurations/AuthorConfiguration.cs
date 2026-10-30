using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BookShop.Infrastructure.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.FirstName)
            .HasMaxLength(64)
            .IsRequired();
        builder.Property(a => a.LastName)
            .HasMaxLength(64)
            .IsRequired();
    }
}