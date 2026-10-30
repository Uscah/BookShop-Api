using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    //public DbSet<> name { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BindingType> BindingTypes { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<BookEdition> BookEditions { get; set; }
    public DbSet<BookStatus> BookStatuses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<InventoryMovement> InventoryMovements { get; set; }
    public DbSet<InventoryMovementDetail> InventoryMovementDetails { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<PaymentProvider> PaymentProviders { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}