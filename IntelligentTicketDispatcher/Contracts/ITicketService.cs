using IntelligentTicketDispatcher.Dtos.Ticket;
using IntelligentTicketDispatcher.Entities;

namespace IntelligentTicketDispatcher.Contracts;

public interface ITicketService
{
    Task<Ticket> CreateTicket(CreateTicketDto dto, int userId);
    Task<TicketMessage> Answer(string answer, int userId, int ticketId);
    Task<Ticket> GetTicketMessages(int ticketId);
}