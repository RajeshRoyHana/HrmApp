namespace HrmApp.Shared.Dtos
{
    public class EmployeeEducationInfoDto
    {
        public int IdClient { get; set; }

        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public int IdEducationLevel { get; set; }

        public int IdEducationExamination { get; set; }

        public int IdEducationResult { get; set; }

        public decimal? Cgpa { get; set; }

        public decimal? ExamScale { get; set; }

        public decimal? Marks { get; set; }

        public string Major { get; set; } = null!;

        public decimal PassingYear { get; set; }

        public string InstituteName { get; set; } = null!;

        public bool IsForeignInstitute { get; set; }

        public decimal? Duration { get; set; }

        public string? Achievement { get; set; }

        public DateTime? SetDate { get; set; }
    }
}
