using IntelligentTicketDispatcher.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntelligentTicketDispatcher.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<DepartmentAdmin> DepartmentAdmins { get; set; }
    public DbSet<AdminTicket> AdminTickets { get; set; }
    public DbSet<TicketAnswer> TicketAnswers { get; set; }
}