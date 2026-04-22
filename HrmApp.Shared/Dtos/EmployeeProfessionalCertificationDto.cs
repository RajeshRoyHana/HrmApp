namespace HrmApp.Shared.Dtos;

using System.ComponentModel.DataAnnotations;

public class EmployeeProfessionalCertificationDto
{
    public int IdClient { get; set; }

    public int Id { get; set; }

    [Required]
    public int IdEmployee { get; set; }

    [Required]
    [MaxLength(255)]
    public string CertificationTitle { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string CertificationInstitute { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string InstituteLocation { get; set; } = null!;

    [Required]
    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public DateTime? SetDate { get; set; }

    [MaxLength(50)]
    public string? CreatedBy { get; set; }
}


