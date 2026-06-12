// RegisterUser.cs - Model for user registration, including properties for user details and validation attributes to ensure proper input
using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class RegisterUser
  {
    [Required, MinLength(3, ErrorMessage = "Username must be at least 3 characters long"), MaxLength(100)]
    public string Username { get; set; } = "";

    [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long"), MaxLength(30)]
    public string Password { get; set; } = "";

    [Required, Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = "";

    [Required, MinLength(3, ErrorMessage = "Company name must be at least 3 characters long"), MaxLength(100)]

    public string CompanyName { get; set; } = "";

    [Required, EmailAddress (ErrorMessage = "Invalid email address")]
    public string CompanyEmail { get; set; } = "";

    [Required]
    public string CompanyAddress { get; set; } = "";

    [Required]
    public string CompanyCity { get; set; } = "";

    [Required]
    public string CompanyState { get; set; } = "";

    [Required, Phone]
    public string CompanyPhone { get; set; } = "";
  }
}