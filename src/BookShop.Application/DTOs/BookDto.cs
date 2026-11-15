namespace BookShop.Application.DTOs;

public record BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; }  = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<AuthorDto> Authors = new List<AuthorDto>();
    public List<CategoryDto> Categories = new List<CategoryDto>();
    public List<BookEditionDto> Editions = new List<BookEditionDto>();
}