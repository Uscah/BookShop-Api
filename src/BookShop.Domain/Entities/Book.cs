namespace BookShop.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
    public bool IsActive { get; set; }  = true;
    public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;
    
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    public ICollection<BookEdition> BookEditions { get; set; } = new List<BookEdition>();
}