using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class Invoice
  {
    public int InvoiceId { get; set; }
    [DataType(DataType.Date)]
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public ICollection<InvoiceProduct> InvoiceProducts { get; } = new List<InvoiceProduct>();
  }
}