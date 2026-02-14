namespace server.DTOs.Branch
{
    public class BranchDto
    {
        public int BranchId { get; set; }

        public string BranchName { get; set; } = null!;

        public string BranchCity { get; set; } = null!;
        public string? BranchAddress { get; set; }


    }
}
