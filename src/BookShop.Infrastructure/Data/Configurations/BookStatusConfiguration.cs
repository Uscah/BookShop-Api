using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class BookStatusConfiguration : IEntityTypeConfiguration<BookStatus>
{
    public void Configure(EntityTypeBuilder<BookStatus> builder)
    {
        builder.ToTable("BookStatus");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.HasData(
            new BookStatus{ Id = 1, Name = "Available"},
            new BookStatus{ Id = 2, Name = "Out Of Stock"},
            new BookStatus{ Id = 3, Name = "PreOrder"},
            new BookStatus{ Id = 4, Name = "Discontinued"}
        );
    }
}