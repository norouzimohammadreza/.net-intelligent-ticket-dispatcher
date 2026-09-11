using IntelligentTicketDispatcher.Enums;

namespace IntelligentTicketDispatcher.Dtos.Ticket;

public record CreateTicketDto(
    string Subject,
    string Body,
    TicketPriority Priority,
    int? DepartmentId
);