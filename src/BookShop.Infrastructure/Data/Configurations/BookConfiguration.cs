using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(a => a.Synopsis)
            .IsRequired()
            .HasMaxLength(128);
        builder.Property(a => a.IsActive)
            .IsRequired();
        builder.Property(a => a.CreatedAt)
            .IsRequired();
    }
}