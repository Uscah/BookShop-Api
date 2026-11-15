namespace BookShop.Application.DTOs;

public record BookSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; }  = string.Empty;
    public bool IsActive { get; set; }
    public List<AuthorDto> Authors = new List<AuthorDto>();
    public List<CategoryDto> Categories = new List<CategoryDto>();
    
}