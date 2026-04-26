namespace HrmApp.Shared.Dtos
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string? EmployeeName { get; set; }
        public string DesignationName { get; set; } = string.Empty;
    }
}
