namespace BookShop.Application.DTOs;

public record CreateBookEditionDto
{
    public string Isbn { get; set; } = string.Empty;
    public int BindingTypeId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int MinimumStock { get; set; } = 10;
    public int Pages { get; set; }
    public decimal Weight { get; set; } = 0;
    public int BookStatusId { get; set; }
    public int PublisherId { get; set; }
    public DateTime? PublishedAt { get; set; }
}