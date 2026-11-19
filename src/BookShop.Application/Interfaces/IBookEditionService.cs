using BookShop.Application.DTOs;

namespace BookShop.Application.Interfaces;

public interface IBookEditionService
{
    Task<int> CreateEditionAsync(int bookId, CreateBookEditionDto dto);
    Task DeleteEditionAsync(int bookId, int editionId);
    Task UpdateEditionAsync(int bookId, int editionId, UpdateBookEditionDto dto);
}