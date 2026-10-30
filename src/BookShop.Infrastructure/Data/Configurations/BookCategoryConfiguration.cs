using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.ToTable("BookCategories");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.Book)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(a => a.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(a => a.Category)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}