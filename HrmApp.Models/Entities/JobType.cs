namespace HrmApp.Models.Entities;

public partial class JobType: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string JobTypeName { get; set; } = null!;

    public string? JobTypeBanglaName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
