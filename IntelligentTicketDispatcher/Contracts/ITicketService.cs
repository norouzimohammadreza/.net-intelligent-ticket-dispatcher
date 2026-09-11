using IntelligentTicketDispatcher.Dtos.Ticket;
using IntelligentTicketDispatcher.Entities;

namespace IntelligentTicketDispatcher.Contracts;

public interface ITicketService
{
    Task<Ticket> CreateTicket(CreateTicketDto dto, int userId);
    Task<TicketAnswer> Answer(string answer, int userId, int ticketId);
}