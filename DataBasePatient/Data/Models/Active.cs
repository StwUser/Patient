using System.ComponentModel.DataAnnotations;

namespace DataBasePatient.Data.Models
{
    public class Active
    {
        [Key]
        public int Id { get; set; }
        public bool Value { get; set; }
        public string? ActiveName { get; set; }    
    }
}
