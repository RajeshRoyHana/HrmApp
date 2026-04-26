namespace HrmApp.Models.Entities;

public partial class EmployeeType: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string? TypeName { get; set; }


    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
