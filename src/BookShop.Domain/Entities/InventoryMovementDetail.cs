namespace BookShop.Domain.Entities;

public class InventoryMovementDetail
{
    public int Id { get; set; }
    public int InventoryMovementId { get; set; }
    public int BookEditionId { get; set; }
    public int Quantity { get; set; }
    public int StockBefore { get; set; }
    public int StockAfter { get; set; }
    
    public BookEdition BookEdition { get; set; }
    public InventoryMovement InventoryMovement { get; set; }
}