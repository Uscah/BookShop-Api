namespace BookShop.Domain.Entities;

public class BookEdition
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int BindingTypeId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int MinimumStock { get; set; }
    public int Pages { get; set; }
    public decimal Weight { get; set; }
    public int BookStatusId { get; set; }
    public int PublisherId { get; set; }
    public DateTime? PublishedAt { get; set; }
    
    public Book Book { get; set; }
    public BindingType BindingType { get; set; }
    public BookStatus BookStatus { get; set; }
    public Publisher Publisher { get; set; } 
    
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<InventoryMovementDetail> InventoryMovementDetails { get; set; } = new List<InventoryMovementDetail>();
}