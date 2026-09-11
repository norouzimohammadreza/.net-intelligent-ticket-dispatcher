using IntelligentTicketDispatcher.Enums;

namespace IntelligentTicketDispatcher.Entities;

public class Ticket : BaseEntity
{
    public int CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    public string Subject { get; private set; }
    public TicketPriority Priority { get; private set; }
    public bool IsOpened { get; private set; } = true;
    public int? DepartmentId { get; private set; }
    public Department? Department { get; private set; }
    public ICollection<AdminTickets> AdminTickets { get; private set; } = [];

    private Ticket()
    {
    }

    public Ticket(int customerId, string subject, TicketPriority priority, int? departmentId)
    {
        CustomerId = customerId;
        Subject = subject;
        Priority = priority;
        DepartmentId = departmentId;
        CreatedAt = DateTime.Now;
    }
}