using System.ComponentModel.DataAnnotations;

namespace HrmApp.Shared.Dtos
{
    public class EmployeeFamilyInfoDto
    {
        public int IdClient { get; set; }

        public int Id { get; set; }

        [Required]
        public int IdEmployee { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public int IdGender { get; set; }

        [Required]
        public int IdRelationship { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? ContactNo { get; set; }

        [MaxLength(500)]
        public string? CurrentAddress { get; set; }

        [MaxLength(500)]
        public string? PermanentAddress { get; set; }

        public DateTime? SetDate { get; set; }

        [MaxLength(50)]
        public string? CreatedBy { get; set; }
    }
}
