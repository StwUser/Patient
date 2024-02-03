using System.ComponentModel.DataAnnotations;

namespace DataBasePatient.Data.Models
{
    public class Given
    {
        [Key]
        public int Id { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public string? GivenName { get; set; }
    }
}
