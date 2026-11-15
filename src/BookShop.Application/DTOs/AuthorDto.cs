namespace BookShop.Application.DTOs;

public record AuthorDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}