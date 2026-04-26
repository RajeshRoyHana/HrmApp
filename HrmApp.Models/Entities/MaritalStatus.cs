namespace HrmApp.Models.Entities;

public partial class MaritalStatus: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string MaritalStatusName { get; set; } = null!;


    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
