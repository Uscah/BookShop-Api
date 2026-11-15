using BookShop.Application.DTOs;

namespace BookShop.Application.Interfaces;

public interface IBookService
{
    Task<List<BookSummaryDto>> GetBooksAsync(BookFilterDto filterDto);
    Task<BookDto> GetBookByIdAsync(int bookId);
    Task<int> CreateBookAsync(CreateBookDto dto);
    Task DeleteBookAsync(int id);
}