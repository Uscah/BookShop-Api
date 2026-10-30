namespace BookShop.Domain.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int BookEditionId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    public BookEdition BookEdition { get; set; }
    public Order Order { get; set; }
}