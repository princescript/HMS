namespace server.DTOs.Doctor
{
    public class DoctorDto
    {
        public int DocId { get; set; }

        public string DocName { get; set; } = null!;

        public string DocSpecialization { get; set; } = null!;

        public string? DocPhone { get; set; }
    }
}
