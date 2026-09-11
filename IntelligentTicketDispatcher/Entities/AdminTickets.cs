namespace IntelligentTicketDispatcher.Entities;

public class AdminTickets
{
    public int AdminId { get; private set; }
    public Admin? Admin { get; private set; }
    public int TicketId { get; private set; }
    public Ticket? Ticket { get; private set; }
    public DateTime AssignedAt { get; private set; }

    private AdminTickets()
    {
    }

    public AdminTickets(int adminId, int ticketId, DateTime assignedAt)
    {
        AdminId = adminId;
        TicketId = ticketId;
        AssignedAt = assignedAt;
    }
}