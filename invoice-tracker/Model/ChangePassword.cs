using System.ComponentModel.DataAnnotations;

namespace InvoiceTracker
{
  public class ChangePasswordModel
  {
    [Required]
    public string CurrentPassword { get; set; } = string.Empty;
    [Required]
    public string NewPassword { get; set; } = string.Empty;
    [Required, Compare(nameof(NewPassword), ErrorMessage ="Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
  }
}