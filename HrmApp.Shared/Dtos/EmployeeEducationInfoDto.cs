using System.ComponentModel.DataAnnotations;

namespace HrmApp.Shared.Dtos
{
    public class EmployeeEducationInfoDto
    {
        public int IdClient { get; set; }

        public int Id { get; set; }

        [Required]
        public int IdEmployee { get; set; }

        [Required]
        public int IdEducationLevel { get; set; }

        [Required]
        public int IdEducationExamination { get; set; }

        [Required]
        public int IdEducationResult { get; set; }

        public decimal? Cgpa { get; set; }

        public decimal? ExamScale { get; set; }

        public decimal? Marks { get; set; }

        [Required]
        [MaxLength(50)]
        public string Major { get; set; } = null!;

        [Required]
        public decimal PassingYear { get; set; }

        [Required]
        [MaxLength(250)]
        public string InstituteName { get; set; } = null!;

        public bool IsForeignInstitute { get; set; }

        public decimal? Duration { get; set; }

        [MaxLength(500)]
        public string? Achievement { get; set; }

        public DateTime? SetDate { get; set; }
    }
}
