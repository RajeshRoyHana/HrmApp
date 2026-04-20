namespace HrmApp.Shared.Dtos
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? EmployeeName { get; set; }
        public string? DesignationName { get; set; }
    }
}
