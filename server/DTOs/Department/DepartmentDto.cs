namespace server.DTOs.Department
{
    public class DepartmentDto
    {
        public int DepartId { get; set; }

        public string DepartName { get; set; } = null!;

        public string? DepartDescription { get; set; }
    }
}
