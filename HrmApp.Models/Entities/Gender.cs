namespace HrmApp.Models.Entities;

public partial class Gender: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string? GenderName { get; set; }


    public virtual ICollection<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; } = new List<EmployeeFamilyInfo>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
