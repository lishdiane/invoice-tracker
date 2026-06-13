// Login.cs - Model for user login, including properties for username and password with validation attributes
using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class LoginModel
  {
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
  }
}