namespace HrmApp.Models.Entities;

public partial class Designation: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string DesignationName { get; set; } = null!;

    public string? DesignationNameBangla { get; set; }

    public bool? IsActive { get; set; }


    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
