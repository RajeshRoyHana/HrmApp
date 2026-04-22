using System.ComponentModel.DataAnnotations;

namespace HrmApp.Shared.Dtos
{
    public class EmployeeDocumentDto
    {
        public int IdClient { get; set; }

        public int Id { get; set; }

        [Required]
        public int IdEmployee { get; set; }

        [Required]
        [MaxLength(200)]
        public string DocumentName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; } = null!;

        [Required]
        public DateTime UploadDate { get; set; }

        [MaxLength(10)]
        public string? UploadedFileExtention { get; set; }

        public string? UploadedFile { get; set; }

        public DateTime? SetDate { get; set; }
    }
}
