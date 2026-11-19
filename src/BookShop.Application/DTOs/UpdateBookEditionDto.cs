namespace BookShop.Application.DTOs;

public record UpdateBookEditionDto
{
    public string? Isbn { get; set; } = string.Empty;
    public int? BindingTypeId { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public int? MinimumStock { get; set; }
    public int? Pages { get; set; }
    public decimal? Weight { get; set; }
    public int? BookStatusId { get; set; }
    public int? PublisherId { get; set; }
    public DateTime? PublishedAt { get; set; }
}