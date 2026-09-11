namespace IntelligentTicketDispatcher.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public int? ParentDepartmentId { get; set; }
    public Department? ParentDepartment { get; set; }
    public ICollection<Department> ChildDepartments { get; private set; } = [];
    public ICollection<AdminDepartment> AdminDepartments { get; private set; } = [];

    private Department()
    {
    }

    public Department(string name, int? parentDepartmentId)
    {
        Name = name;
        ParentDepartmentId = parentDepartmentId;
    }
}