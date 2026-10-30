namespace BookShop.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public Guid PublicId { get; set; } = Guid.CreateVersion7();
    public int UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public int PaymentProviderId { get; set; }
    public string PaymentIdReference { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int OrderStatusId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public User User { get; set; }
    public PaymentProvider PaymentProvider { get; set; }
    public OrderStatus OrderStatus { get; set; }
    
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<InventoryMovement>  InventoryMovements { get; set; } = new List<InventoryMovement>();
}