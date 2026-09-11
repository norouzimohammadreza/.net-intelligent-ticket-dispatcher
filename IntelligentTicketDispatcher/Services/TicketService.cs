using IntelligentTicketDispatcher.Context;
using IntelligentTicketDispatcher.Contracts;
using IntelligentTicketDispatcher.Dtos.Ticket;
using IntelligentTicketDispatcher.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntelligentTicketDispatcher.Services;

public class TicketService(ApplicationDbContext dbContext) : ITicketService
{
    public async Task<Ticket> CreateTicket(CreateTicketDto dto, int userId)
    {
        if (userId <= 0)
        {
            throw new UnauthorizedAccessException();
        }

        var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.UserId == userId);

        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var assignedAdminId = await _AssignedAdmin(dto.DepartmentId);

        var ticket = new Ticket(
            userId,
            dto.Subject,
            dto.Body,
            dto.Priority,
            assignedAdminId
        ); 
        dbContext.Tickets.Add(ticket);
        await dbContext.SaveChangesAsync();
        
        return ticket;
    }

    private async Task<int> _AssignedAdmin(int? departmentId)
    {
        var adminIds = await dbContext.AdminDepartments
            .Select(x => new { x.AdminId, x.DepartmentId })
            .Distinct()
            .ToListAsync();

        if (departmentId != null)
        {
            var departmentAdminIds = adminIds
                .Where(x => x.DepartmentId == departmentId)
                .Select(x => x.AdminId)
                .ToList();

            var ticketDepartmentAdmins = await dbContext.AdminTickets
                .Include(x => x.Ticket)
                .Where(x => departmentAdminIds.Contains(x.AdminId) && x.Ticket!.IsOpened == true)
                .Select(x => new { x.AdminId })
                .ToListAsync();

            var adminsOpenTicketsCount = ticketDepartmentAdmins.ToDictionary(k => k.AdminId,
                v => ticketDepartmentAdmins.Count(x => departmentAdminIds.Contains(x.AdminId))).OrderBy(x => x.Value);

            var lessTicketsAdmin = adminsOpenTicketsCount.First();

            if (lessTicketsAdmin.Value <= 5)
            {
                return lessTicketsAdmin.Key;
            }
        }

        var selectedAdminIds = adminIds
            .Select(x => x.AdminId)
            .ToList();

        var ticketsAdmins = await dbContext.AdminTickets
            .Include(x => x.Ticket)
            .Where(x => selectedAdminIds.Contains(x.AdminId) && x.Ticket!.IsOpened == true)
            .Select(x => new { x.AdminId })
            .ToListAsync();

        var adminTicketsCount = ticketsAdmins.ToDictionary(k => k.AdminId,
            v => ticketsAdmins.Count(x => selectedAdminIds.Contains(x.AdminId))).OrderBy(x => x.Value);

        return adminTicketsCount.First().Key;
    }
}