namespace BookShop.Application.DTOs;

public record CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
    public List<CreateBookEditionDto> Editions = new List<CreateBookEditionDto>();
    public List<AuthorDto> Authors = new List<AuthorDto>();
    public List<CategoryDto> Categories = new List<CategoryDto>();
}