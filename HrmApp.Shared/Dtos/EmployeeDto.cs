using System.ComponentModel.DataAnnotations;

namespace HrmApp.Shared.Dtos;

public class EmployeeDto
{
    [Required]
    public int IdClient { get; set; }

    public int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string? EmployeeName { get; set; }

    [StringLength(250)]
    public string? EmployeeNameBangla { get; set; }

    public byte[]? EmployeeImage { get; set; }

    [StringLength(250)]
    public string? FatherName { get; set; }

    [StringLength(250)]
    public string? MotherName { get; set; }

    public int? IdReportingManager { get; set; }

    public int? IdJobType { get; set; }

    public int? IdEmployeeType { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? JoiningDate { get; set; }

    public int? IdGender { get; set; }

    public int? IdReligion { get; set; }

    [Required]
    public int IdDepartment { get; set; }

    [Required]
    public int IdSection { get; set; }

    public int? IdDesignation { get; set; }

    public bool? HasOvertime { get; set; }

    public bool? HasAttendenceBonus { get; set; }

    public int? IdWeekOff { get; set; }

    [StringLength(250)]
    public string? Address { get; set; }

    [StringLength(250)]
    public string? PresentAddress { get; set; }

    [StringLength(30)]
    public string? NationalIdentificationNumber { get; set; }

    [StringLength(250)]
    [Phone]
    public string? ContactNo { get; set; }

    public int? IdMaritalStatus { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? SetDate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }
}
