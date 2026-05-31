using InvoiceTracker;
using Microsoft.EntityFrameworkCore;

namespace InvoiceTracker.Data
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using var context = new InvoiceTrackerContext(
          serviceProvider.GetRequiredService<DbContextOptions<InvoiceTrackerContext>>());

      if (context.Users.Any()) return;

      var users = new List<User>
            {
                new User
                {
                    Username = "jsmith",
                    Password = "hashed_password_1",
                    CompanyName = "Smith Consulting LLC",
                    CompanyEmail = "info@smithconsulting.com",
                    CompanyAddress = "123 Main Street",
                    CompanyCity = "Pocatello",
                    CompanyState = "ID",
                    CompanyPhone = "2085550101"
                },
                new User
                {
                    Username = "mgarcia",
                    Password = "hashed_password_2",
                    CompanyName = "Garcia Design Co",
                    CompanyEmail = "hello@garciadesign.com",
                    CompanyAddress = "456 Oak Avenue",
                    CompanyCity = "Boise",
                    CompanyState = "ID",
                    CompanyPhone = "2085550202"
                }
            };

      context.Users.AddRange(users);
      context.SaveChanges();

      var clients = new List<Client>
            {
                new Client
                {
                    ClientName = "Acme Corporation",
                    ClientEmail = "billing@acme.com",
                    ClientPhone = "2085550301",
                    ClientAddress = "789 Business Blvd",
                    ClientCity = "Idaho Falls",
                    ClientState = "ID",
                    UserId = users[0].UserId
                },
                new Client
                {
                    ClientName = "TechStart Inc",
                    ClientEmail = "accounts@techstart.com",
                    ClientPhone = "2085550302",
                    ClientAddress = "321 Innovation Drive",
                    ClientCity = "Nampa",
                    ClientState = "ID",
                    UserId = users[0].UserId
                },
                new Client
                {
                    ClientName = "Green Earth Co",
                    ClientEmail = "finance@greenearth.com",
                    ClientPhone = "2085550303",
                    ClientCity = "Twin Falls",
                    ClientState = "ID",
                    UserId = users[1].UserId
                },
                new Client
                {
                    ClientName = "Blue Sky Media",
                    ClientPhone = "2085550304",
                    ClientAddress = "654 Sunset Lane",
                    ClientCity = "Meridian",
                    ClientState = "ID",
                    UserId = users[1].UserId
                }
            };

      context.Clients.AddRange(clients);
      context.SaveChanges();

      var products = new List<Product>
            {
                new Product { ProductName = "Web Consulting", ProductPrice = 150.00m, UserId = users[0].UserId },
                new Product { ProductName = "SEO Audit", ProductPrice = 500.00m, UserId = users[0].UserId },
                new Product { ProductName = "Monthly Retainer", ProductPrice = 2000.00m, UserId = users[0].UserId },
                new Product { ProductName = "Logo Design", ProductPrice = 800.00m, UserId = users[1].UserId },
                new Product { ProductName = "Brand Package", ProductPrice = 2500.00m, UserId = users[1].UserId },
                new Product { ProductName = "Social Media Kit", ProductPrice = 600.00m, UserId = users[1].UserId }
            };

      context.Products.AddRange(products);
      context.SaveChanges();

      var invoices = new List<Invoice>
{
    new Invoice
    {
        InvoiceDate = DateTime.UtcNow.AddDays(-30),
        DueDate = DateTime.UtcNow.AddDays(-15),
        IsPaid = true,
        UserId = users[0].UserId,
        ClientId = clients[0].ClientId
    },
    new Invoice
    {
        InvoiceDate = DateTime.UtcNow.AddDays(-15),
        DueDate = DateTime.UtcNow.AddDays(15),
        IsPaid = false,
        UserId = users[0].UserId,
        ClientId = clients[1].ClientId
    },
    new Invoice
    {
        InvoiceDate = DateTime.UtcNow.AddDays(-7),
        DueDate = DateTime.UtcNow.AddDays(23),
        IsPaid = false,
        UserId = users[0].UserId,
        ClientId = clients[0].ClientId
    },
    new Invoice
    {
        InvoiceDate = DateTime.UtcNow.AddDays(-20),
        DueDate = DateTime.UtcNow.AddDays(-5),
        IsPaid = false,
        UserId = users[1].UserId,
        ClientId = clients[2].ClientId
    },
    new Invoice
    {
        InvoiceDate = DateTime.UtcNow.AddDays(-10),
        DueDate = DateTime.UtcNow.AddDays(20),
        IsPaid = true,
        UserId = users[1].UserId,
        ClientId = clients[3].ClientId
    }
};

      context.Invoices.AddRange(invoices);
      context.SaveChanges();

      var invoiceProducts = new List<InvoiceProduct>
            {
                new InvoiceProduct { InvoiceId = invoices[0].InvoiceId, ProductId = products[0].ProductId, Quantity = 10, Price = 150.00m },
                new InvoiceProduct { InvoiceId = invoices[0].InvoiceId, ProductId = products[1].ProductId, Quantity = 1, Price = 500.00m },
                new InvoiceProduct { InvoiceId = invoices[1].InvoiceId, ProductId = products[2].ProductId, Quantity = 1, Price = 2000.00m },
                new InvoiceProduct { InvoiceId = invoices[2].InvoiceId, ProductId = products[0].ProductId, Quantity = 5, Price = 150.00m },
                new InvoiceProduct { InvoiceId = invoices[3].InvoiceId, ProductId = products[3].ProductId, Quantity = 1, Price = 800.00m },
                new InvoiceProduct { InvoiceId = invoices[3].InvoiceId, ProductId = products[5].ProductId, Quantity = 1, Price = 600.00m },
                new InvoiceProduct { InvoiceId = invoices[4].InvoiceId, ProductId = products[4].ProductId, Quantity = 1, Price = 2500.00m }
            };

      context.InvoiceProducts.AddRange(invoiceProducts);
      context.SaveChanges();
    }
  }
}