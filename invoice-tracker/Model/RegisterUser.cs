// RegisterUser.cs - Model for user registration, including properties for user details and validation attributes to ensure proper input
using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class RegisterUser
  {
    [Required(ErrorMessage = "Please create a username"), MinLength(3, ErrorMessage = "Username must be at least 3 characters long"), MaxLength(100)]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Please create a password"), MinLength(6, ErrorMessage = "Password must be at least 6 characters long"), MaxLength(30)]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Please confirm your password"), Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = "";

    [Required(ErrorMessage = "Please enter your company's name"), MinLength(3, ErrorMessage = "Company name must be at least 3 characters long"), MaxLength(100)]

    public string CompanyName { get; set; } = "";

    [Required(ErrorMessage = "Please enter a valid email address"), EmailAddress (ErrorMessage = "Invalid email address")]
    public string CompanyEmail { get; set; } = "";

    [Required(ErrorMessage = "Please enter your company's street address")]
    public string CompanyAddress { get; set; } = "";

    [Required(ErrorMessage = "Please enter a city")]
    public string CompanyCity { get; set; } = "";

    [Required(ErrorMessage = "Please enter a state")]
    public string CompanyState { get; set; } = "";

    [Required, Phone]
    public string CompanyPhone { get; set; } = "";
  }
}