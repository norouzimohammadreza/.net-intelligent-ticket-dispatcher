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
        if (departmentId != null)
        {
            var departmentAdmins = await dbContext.DepartmentAdmins
                .Where(x => x.DepartmentId == departmentId)
                .Select(x => new
                    { AdminId = x.AdminId, Count = x.Admin!.AdminTickets.Count(at => at.Ticket!.IsOpened == true) })
                .OrderBy(x => x.Count)
                .FirstOrDefaultAsync();

            if (departmentAdmins!.Count <= 5)
            {
                return departmentAdmins!.AdminId;
            }
        }

        var admins = await dbContext.Admins
            .Select(x => new { AdminId = x.Id, Count = x.AdminTickets.Count(at => at.Ticket!.IsOpened == true) })
            .OrderBy(x => x.Count)
            .FirstOrDefaultAsync();
        
        return admins!.AdminId;
    }
}