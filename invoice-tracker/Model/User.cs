using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class User
  {
    public int UserId { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string CompanyName { get; set; }
    [Required, EmailAddress]
    public required string CompanyEmail { get; set; }
    [Required]
    public required string CompanyAddress { get; set; }
    [Required]
    public required string CompanyCity { get; set; }
    [Required]
    public required string CompanyState { get; set; }
    [Required, Phone]
    public required string CompanyPhone { get; set; }
    public ICollection<Product> Products { get; } = new List<Product>();
    public ICollection<Client> Clients { get; } = new List<Client>();
    public ICollection<Invoice> Invoices { get; } = new List<Invoice>();
  }
}