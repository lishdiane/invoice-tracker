using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class Product
  {
    public int ProductId { get; set; }
    [Required]
    public required string ProductName { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal ProductPrice { get; set; }
    public bool IsArchived { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<InvoiceProduct> InvoiceProducts { get; } = new List<InvoiceProduct>();

  }
}