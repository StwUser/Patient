
namespace DataBasePatient.Data.Dtos
{
    public class PatientDto
    {
        public NameDto Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirtDate { get; set; }
        public bool? Active { get; set; }
    }
}
