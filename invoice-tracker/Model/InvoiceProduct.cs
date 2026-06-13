// InvoiceProduct.cs - Represents the many-to-many relationship between invoices and products, including properties for quantity and price, and validation attributes for these fields
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace InvoiceTracker
{
  [PrimaryKey(nameof(InvoiceId), nameof(ProductId))]
  public class InvoiceProduct
  {
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
  }
}