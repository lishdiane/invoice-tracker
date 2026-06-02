
namespace InvoiceTracker;

public class UserSession
{
    public bool IsAuthenticated { get; set; }

    public int UserId { get; set; }

    public string Username { get; set; } = string.Empty;
}