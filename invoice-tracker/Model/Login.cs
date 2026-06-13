// Login.cs - Model for user login, including properties for username and password with validation attributes
using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class LoginModel
  {
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
  }
}