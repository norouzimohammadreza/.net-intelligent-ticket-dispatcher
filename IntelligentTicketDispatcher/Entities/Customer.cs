namespace IntelligentTicketDispatcher.Entities;

public class Customer : BaseEntity
{
    public int UserId{ get; private set; }
    public User? User { get; private set; }
    
    private Customer(){}
    
    public Customer(int userId)
    {
        UserId = userId;
    }
}