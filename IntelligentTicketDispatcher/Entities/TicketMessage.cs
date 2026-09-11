namespace IntelligentTicketDispatcher.Entities;

public class TicketMessage : BaseEntity
{
    public int? AdminId { get; private set; }
    public Admin? Admin { get; private set; }
    public int TicketId { get; private set; }
    public Ticket? Ticket { get; private set; }
    public bool isAdmin { get; private set; } = true;
    public string Answer { get; private set; }

    private TicketMessage()
    {
    }

    public TicketMessage(int ticketId, string answer, int? adminId)
    {
        AdminId = adminId;
        TicketId = ticketId;
        Answer = answer;
        CreatedAt = DateTime.UtcNow;
    }
}