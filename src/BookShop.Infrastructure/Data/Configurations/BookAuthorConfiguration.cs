using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("BookAuthors");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(a => a.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(a => a.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}