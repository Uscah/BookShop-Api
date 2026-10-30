using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Data.Configurations;

public class BookEditionConfiguration : IEntityTypeConfiguration<BookEdition>
{
    public void Configure(EntityTypeBuilder<BookEdition> builder)
    {
        builder.ToTable("BookEditions");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.Book)
            .WithMany(b => b.BookEditions)
            .HasForeignKey(a => a.BookId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.Isbn)
            .IsRequired()
            .HasMaxLength(13);
        builder.HasIndex(a => a.Isbn)
            .IsUnique();
        builder.HasOne(a => a.BindingType)
            .WithMany(b => b.BookEditions)
            .HasForeignKey(a => a.BindingTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.Price)
            .IsRequired()
            .HasPrecision(18, 2);
        builder.Property(a => a.Stock)
            .IsRequired();
        builder.Property(a => a.MinimumStock)
            .IsRequired();
        builder.Property(a => a.Pages)
            .IsRequired();
        builder.Property(a => a.Weight)
            .IsRequired()
            .HasPrecision(6, 2);
        builder.HasOne(a => a.BookStatus)
            .WithMany(b => b.BookEditions)
            .HasForeignKey(a => a.BookStatusId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(a => a.Publisher)
            .WithMany(b => b.BookEditions)
            .HasForeignKey(a => a.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.PublishedAt)
            .IsRequired(false);
    }
}