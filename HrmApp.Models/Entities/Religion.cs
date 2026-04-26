namespace HrmApp.Models.Entities;

public partial class Religion: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string ReligionName { get; set; } = null!;


    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
