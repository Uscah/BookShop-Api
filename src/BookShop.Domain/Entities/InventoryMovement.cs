namespace BookShop.Domain.Entities;

public class InventoryMovement
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MovementTypeId { get; set; }
    public int OrderId { get; set; }
    public string Description { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public MovementType MovementType { get; set; }
    public User? User { get; set; }
    public Order? Order { get; set; }
    
    public ICollection<InventoryMovementDetail> InventoryMovementDetails { get; set; } = new List<InventoryMovementDetail>();
}
