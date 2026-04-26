namespace HrmApp.Models.Entities;

public partial class EducationResult: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string ResultName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<EmployeeEducationInfo> EmployeeEducationInfos { get; set; } = new List<EmployeeEducationInfo>();
}
