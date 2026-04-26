namespace HrmApp.Models.Entities;

public partial class Relationship: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string RelationName { get; set; } = null!;

    public string? Description { get; set; }


    public virtual ICollection<EmployeeFamilyInfo> EmployeeFamilyInfos { get; set; } = new List<EmployeeFamilyInfo>();
}
