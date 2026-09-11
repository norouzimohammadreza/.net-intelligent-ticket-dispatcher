namespace IntelligentTicketDispatcher.Entities;

public class Admin : BaseEntity
{
    public int UserId { get; private set; }
    public User? User { get; private set; }
    public ICollection<AdminTicket> AdminTickets { get; private set; } = [];
    public ICollection<DepartmentAdmin> AdminDepartments { get; private set; } = [];

    private Admin()
    {
    }

    public Admin(int userId)
    {
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }
}