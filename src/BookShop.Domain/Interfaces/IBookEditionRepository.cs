using BookShop.Domain.Entities;

namespace BookShop.Domain.Interfaces;

public interface IBookEditionRepository
{
    Task SaveAsync();
    Task CreateEditionAsync(BookEdition edition);
    void DeleteEdition(BookEdition edition);
    Task<BookEdition?> GetBookEditionAsync(int bookId, int editionId);
}