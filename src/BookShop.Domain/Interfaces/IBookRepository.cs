using BookShop.Domain.Entities;
using BookShop.Domain.Filters;

namespace BookShop.Domain.Interfaces;

public interface IBookRepository
{
    Task SaveAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<List<Book>> GetBooksAsync(BookFilter filter);
    Task PostBookAsync(Book book);
    void DeleteBook(Book book);
    Task<bool> BookExists(int bookId);
}