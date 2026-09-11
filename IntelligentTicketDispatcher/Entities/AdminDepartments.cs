namespace IntelligentTicketDispatcher.Entities;

public class AdminDepartments
{
    public int AdminId { get; private set; }
    public Admin? Admin { get; private set; }
    public int DepartmentId { get; private set; }
    public Department? Department { get; private set; }

    private AdminDepartments(){}

    public AdminDepartments(int adminId, int departmentId)
    {
        AdminId = adminId;
        DepartmentId = departmentId;
    }
}