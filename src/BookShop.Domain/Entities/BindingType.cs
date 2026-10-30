namespace BookShop.Domain.Entities;

public class BindingType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<BookEdition> BookEditions { get; set; } = new List<BookEdition>();
}