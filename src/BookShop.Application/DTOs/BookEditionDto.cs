namespace BookShop.Application.DTOs;

public record BookEditionDto
{
    public int Id { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int BindingTypeId { get; set; }
    public string BindingType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int MinimumStock { get; set; }
    public int Pages { get; set; }
    public decimal Weight { get; set; }
    public int BookStatusId { get; set; }
    public string Status { get; set; } = string.Empty;
    public int PublisherId { get; set; }
    public string PublisherName { get; set; } = string.Empty;
    public DateTime? PublishedAt { get; set; }
}