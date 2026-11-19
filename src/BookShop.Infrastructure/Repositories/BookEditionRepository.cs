using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using BookShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class BookEditionRepository : IBookEditionRepository
{
    private readonly AppDbContext _context;
    public BookEditionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    //Get
    public async Task<BookEdition?> GetBookEditionAsync(int bookId, int editionId)
    {
        return await _context.BookEditions.FirstOrDefaultAsync(a => a.Id == editionId && a.BookId == bookId);
    }
    
    //Post
    public async Task CreateEditionAsync(BookEdition edition)
    {
        await _context.BookEditions.AddAsync(edition);
    }
    //Delete
    public void DeleteEdition(BookEdition edition)
    {
        _context.BookEditions.Remove(edition);
    }
    //
    
}