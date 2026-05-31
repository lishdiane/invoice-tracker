using Microsoft.EntityFrameworkCore;

namespace InvoiceTracker;

public class InvoiceTrackerContext : DbContext
{
  public InvoiceTrackerContext(DbContextOptions options) : base(options)
  {

  }
  public DbSet<Client> Clients { get; set; }
  public DbSet<Invoice> Invoices { get; set; }
  public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<User> Users { get; set; }

}