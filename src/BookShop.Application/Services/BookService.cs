using BookShop.Application.DTOs;
using BookShop.Application.Interfaces;
using BookShop.Domain.Entities;
using BookShop.Domain.Filters;
using BookShop.Domain.Interfaces;
using Mapster;

namespace BookShop.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> GetBookByIdAsync(int bookId)
    {
        if (bookId is 0 or < 0) throw new ArgumentException("bookId no es valido");
        
        var book = await _bookRepository.GetBookByIdAsync(bookId) ?? throw new KeyNotFoundException("El libro no existe");
        return book.Adapt<BookDto>();
    }

    public async Task<List<BookSummaryDto>> GetBooksAsync(BookFilterDto filterDto)
    {
        var filter = filterDto.Adapt<BookFilter>();
        var books = await _bookRepository.GetBooksAsync(filter);
        
        return books.Adapt<List<BookSummaryDto>>();
    }

    public async Task<int> CreateBookAsync(CreateBookDto dto)
    {
        var entity = new Book
        {
            Title = dto.Title,
            Synopsis = dto.Synopsis,
            BookEditions = dto.Editions.Adapt<List<BookEdition>>(),
            BookAuthors = dto.Authors.Select(a => new BookAuthor { AuthorId = a.Id }).ToList(),
            BookCategories = dto.Categories.Select(a => new BookCategory { CategoryId = a.Id }).ToList()
        };
        await _bookRepository.PostBookAsync(entity);
        await _bookRepository.SaveAsync();
        var entityId = entity.Id;
        return entityId;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id) ?? throw new KeyNotFoundException("El libro no existe");
        _bookRepository.DeleteBook(book);
        await _bookRepository.SaveAsync();
    }
    
}