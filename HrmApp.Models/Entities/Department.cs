namespace HrmApp.Models.Entities;

public partial class Department: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string DepartName { get; set; } = null!;

    public string? DepartNameBangla { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
