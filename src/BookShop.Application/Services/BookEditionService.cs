using BookShop.Application.DTOs;
using BookShop.Application.Interfaces;
using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using Mapster;

namespace BookShop.Application.Services;

public class BookEditionService : IBookEditionService
{
    private readonly IBookEditionRepository _editionRepository;
    private readonly IBookService _bookService;
    private readonly IBookRepository _bookRepository;
    
    public BookEditionService(IBookEditionRepository editionRepository, IBookService bookService, IBookRepository bookRepository)
    {
        _editionRepository = editionRepository;
        _bookService = bookService;
        _bookRepository = bookRepository;
    }

    public async Task<int> CreateEditionAsync(int bookId, CreateBookEditionDto dto)
    {
        var book = await _bookService.GetBookByIdAsync(bookId);
        var edition = dto.Adapt<BookEdition>();
        edition.BookId = bookId;
        await _editionRepository.CreateEditionAsync(edition);
        await _editionRepository.SaveAsync();
        return edition.Id;
    }

    public async Task DeleteEditionAsync(int bookId, int editionId)
    {
        if (!await _bookRepository.BookExists(bookId)) throw new KeyNotFoundException("El libro no existe");
        
        var edition = await _editionRepository.GetBookEditionAsync(bookId, editionId) ?? throw new KeyNotFoundException("El edition no existe");
        _editionRepository.DeleteEdition(edition);
        await _editionRepository.SaveAsync();
    }

    public async Task UpdateEditionAsync(int bookId, int editionId, UpdateBookEditionDto dto)
    {
        if (!await _bookRepository.BookExists(bookId)) throw new KeyNotFoundException("El libro no existe");
        
        var edition = await _editionRepository.GetBookEditionAsync(bookId, editionId) ?? throw new KeyNotFoundException("El edition no existe");
        ApplyUpdate(edition, dto);
        await _editionRepository.SaveAsync();
    }


    private static void ApplyUpdate(BookEdition edition, UpdateBookEditionDto dto)
    {
        //if (dto.Isbn is not null) edition.Isbn = dto.Isbn
        edition.Isbn = dto.Isbn ??  edition.Isbn;
        edition.BindingTypeId = dto.BindingTypeId ??  edition.BindingTypeId;
        edition.Price = dto.Price ??  edition.Price;
        edition.Stock =  dto.Stock ??  edition.Stock;
        edition.MinimumStock = dto.MinimumStock ??  edition.MinimumStock;
        edition.Pages = dto.Pages ??  edition.Pages;
        edition.Weight = dto.Weight ??  edition.Weight;
        edition.BookStatusId = dto.BookStatusId ??  edition.BookStatusId;
        edition.PublisherId = dto.PublisherId ??  edition.PublisherId;
        edition.PublishedAt = dto.PublishedAt ??  edition.PublishedAt;
    }
}