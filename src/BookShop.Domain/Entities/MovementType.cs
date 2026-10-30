namespace BookShop.Domain.Entities;

public class MovementType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
}