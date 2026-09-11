namespace IntelligentTicketDispatcher.Entities;

public class Department : BaseEntity
{
    public string Name { get; private set; }
    public int? ParentDepartmentId { get; private set; }
    public Department? ParentDepartment { get; private set; }
    public ICollection<Department> ChildDepartments { get; private set; } = [];
    public ICollection<DepartmentAdmin> AdminDepartments { get; private set; } = [];

    private Department()
    {
    }

    public Department(string name, int? parentDepartmentId)
    {
        Name = name;
        ParentDepartmentId = parentDepartmentId;
        CreatedAt = DateTime.UtcNow;
    }
}