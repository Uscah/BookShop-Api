namespace BookShop.Domain.Entities;

public class BookStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<BookEdition> BookEditions { get; set; } = new List<BookEdition>();
}