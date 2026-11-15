namespace BookShop.Application.DTOs;

public record BookFilterDto
{
    public string? Title { get; set; } = string.Empty;
    public int? BindingTypeId { get; set; }
    public int? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}