using System.ComponentModel.DataAnnotations;

namespace DataBasePatient.Data.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string? GenderName { get; set; }
    }
}
