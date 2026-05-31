using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class Client
  {
    public int ClientId { get; set; }
    [Required]
    public required string ClientName { get; set; }
    [EmailAddress]
    public string? ClientEmail { get; set; }
    [Required, Phone]
    public required string ClientPhone { get; set; }
    public string? ClientAddress { get; set; }
    public string? ClientCity { get; set; }
    public string? ClientState { get; set; }
    public bool IsArchived { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Invoice> Invoices { get; } = new List<Invoice>();
  }
}