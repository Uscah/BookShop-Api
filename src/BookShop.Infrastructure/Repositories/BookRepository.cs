using BookShop.Domain.Entities;
using BookShop.Domain.Filters;
using BookShop.Domain.Interfaces;
using BookShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    // Get
    public async Task<Book?> GetBookByIdAsync(int id)
    {
        var book = await _context.Books.
            Include(a => a.BookAuthors)
                .ThenInclude(b => b.Author)
            .Include(a => a.BookCategories)
                .ThenInclude(b => b.Category)
            .Include(a => a.BookEditions)
                .ThenInclude(b => b.Publisher)
            .Include(a => a.BookEditions)
                .ThenInclude(b => b.BookStatus)
            .Include(a => a.BookEditions)
                .ThenInclude(b => b.BindingType)
            .FirstOrDefaultAsync(a => a.Id == id);
        return book;
    }

    public async Task<List<Book>> GetBooksAsync(BookFilter filter)
    {
        var query = _context.Books
            .Include(a => a.BookAuthors)
            .ThenInclude(b => b.Author)
            .Include(a => a.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking();

        if (!String.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title));
        }
        if (filter.CategoryId.HasValue)
        {
            query = query.Where(a => a.BookCategories.Any(b => b.CategoryId == filter.CategoryId));
        }
        if (filter.BindingTypeId.HasValue)
        {
            query = query.Where(a => a.BookEditions.Any(b => b.BindingTypeId == filter.BindingTypeId));
        }
        if (filter.MinPrice.HasValue)
        {
            query = query.Where(a => a.BookEditions.Any(b => b.Price >= filter.MinPrice));
        }
        if (filter.MaxPrice.HasValue)
        {
            query = query.Where(a => a.BookEditions.Any(b => b.Price <= filter.MaxPrice));
        }
        
        var books = await query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        
        return books;
    }
    //Post
    public async Task PostBookAsync(Book book)
    {
        await _context.Books.AddAsync(book);
    }
    
    //Delete
    public void DeleteBook(Book book)
    {
        _context.Books.Remove(book);
    }
    
}