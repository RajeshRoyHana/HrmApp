namespace HrmApp.Shared.Dtos
{
    public class EmployeeDocumentDto
    {
        public int IdClient { get; set; }

        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public string DocumentName { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public DateTime UploadDate { get; set; }

        public string? UploadedFileExtention { get; set; }

        public string? UploadedFile { get; set; }

        public DateTime? SetDate { get; set; }
    }
}
