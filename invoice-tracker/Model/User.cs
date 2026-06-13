// User.cs - Represents a user in the invoice tracking system, including properties for account and company information, as well as relationships to products, clients, and invoices
using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class User
  {
    // Account Info
    public int UserId { get; set; }
    [Required, MinLength(3, ErrorMessage = "Username must be at least 3 characters long"), MaxLength(100)]
    public required string Username { get; set; }
    [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long"), MaxLength(30)]
    public required string Password { get; set; }
  
    // Company Info
    [Required, MinLength(3, ErrorMessage = "Company name must be at least 3 characters long"), MaxLength(100)]
    public required string CompanyName { get; set; }
    [Required, EmailAddress (ErrorMessage = "Invalid email address")]
    public required string CompanyEmail { get; set; }

    // Company Address
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