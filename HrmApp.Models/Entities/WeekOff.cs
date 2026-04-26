namespace HrmApp.Models.Entities;

public partial class WeekOff: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string? WeekOffDay { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
