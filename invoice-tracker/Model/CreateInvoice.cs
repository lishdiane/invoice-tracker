using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class CreateInvoiceModel : IValidatableObject
  {
    [Required, Range(1, int.MaxValue, ErrorMessage = "Please select a client.")]
    public int ClientId { get; set; }
    [Required]
    public DateTime InvoiceDate { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public List<CreateInvoiceLine> Lines { get; set; } = new();

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
      if (DueDate <= InvoiceDate)
      {
        yield return new ValidationResult(
            "Due date must be after invoice date.",
            new[] { nameof(DueDate) });
      }
    }
  }

  public class CreateInvoiceLine
  {
    // Allows for multiple products per invoice
    [Required, Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
    public int ProductId { get; set; }
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; } = 1;

    // Used for adding new products
    public bool IsAddingNewProduct { get; set; }
    public string NewProductName { get; set; } = "";
    public decimal NewProductPrice { get; set; }
  }
}