namespace HrmApp.Models.Entities;

public partial class EducationLevel: AuditEntity
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    public string EducationLevelName { get; set; } = null!;

    public string? Description { get; set; }


    public virtual ICollection<EducationExamination> EducationExaminations { get; set; } = new List<EducationExamination>();

    public virtual ICollection<EmployeeEducationInfo> EmployeeEducationInfos { get; set; } = new List<EmployeeEducationInfo>();
}
