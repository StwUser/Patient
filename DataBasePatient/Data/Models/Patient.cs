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
        public ICollection<Given> Givens { get; } = new List<Given>();
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public int? ActiveId { get; set; }
        public Active? Active { get; set; }
    }
}
