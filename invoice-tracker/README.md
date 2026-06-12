
# Invoice Tracker
 
A full-stack web application for freelancers and small businesses to create, manage, and track invoices. Built with ASP.NET Core Blazor Server, Entity Framework Core, and PostgreSQL, with user authentication, responsive design, and full CRUD functionality.
 
🔗 [Live Application](https://invoice-tracker-363n.onrender.com) 
 
---
 
## Tech Stack
 
| Layer | Technology |
|---|---|
| Framework | ASP.NET Core (.NET 10) Blazor Server |
| UI | Razor Components, Bootstrap 5 |
| Database | PostgreSQL (Supabase) |
| ORM | Entity Framework Core + Npgsql |
| Auth | Custom UserSession service, ASP.NET Core PasswordHasher|
| Deployment | Render |
 
---
 
## Features
 
**Authentication & Accounts**
- User registration and login with hashed passwords
- Account management including company information and password changes
- All data scoped to the authenticated user — no cross-account data exposure
**Invoice Management**
- Create invoices with client, product, quantity, price, invoice date, and due date
- View all invoices in a sortable, filterable table
- Filter by client name, payment status, and date range
- Sort by client name, invoice date, and total amount
- Edit and delete invoices
- Automatic total calculation based on line items
**Client Management**
- Add clients tied to your account
- Client archiving support
**Product Management**
- Define billable services or products with default pricing
- Price is captured at the time of invoicing to preserve historical accuracy even if the product price changes later
**Responsive Design**
- Table layout on desktop
- Card-based layout on mobile and tablet
---
 
## Database Schema
 
Five-table relational schema designed to support multi-user data isolation and accurate historical invoice records:
 
- **User** — account and company information
- **Client** — belongs to a user; represents who gets billed
- **Product** — belongs to a user; represents a billable service or item
- **Invoice** — belongs to a user; tracks dates and payment status
- **InvoiceProduct** — join table with composite primary key (`InvoiceId`, `ProductId`); stores quantity and price at the time of invoicing
---
 
## Key Concepts Demonstrated
 
- Blazor Server interactive rendering with `@rendermode InteractiveServer`
- Entity Framework Core with LINQ filtering, sorting, and eager loading via `.Include()`
- User-scoped data queries using `.Where()` to prevent cross-account data access
- Password hashing with ASP.NET Core `PasswordHasher<T>`
- Session-based authentication using a custom `UserSession` service scoped per user connection
- Responsive UI with Bootstrap 5 and custom CSS
---
 
## Contributors
 
- Diane Lish
- Steve Buamikusu KALALA
- Madison Thomas
- Grace Ayuso
- Iruoghene Sasha Omarayeirue