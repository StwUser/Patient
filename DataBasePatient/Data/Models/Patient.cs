using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataBasePatient.Data.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Use { get; set; }
        [Required]
        public string? Family { get; set; }
        public List<string> Given { get; } = new List<string>();
        public Gender? Gender { get; set; }
        public int GenderId { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public Active? Active { get; set; }

    }
}
