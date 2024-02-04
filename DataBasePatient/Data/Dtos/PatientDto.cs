
using DataBasePatient.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataBasePatient.Data.Dtos
{
    public class PatientDto
    {
        public NameDto? Name { get; set; }

        [RegularExpression($"^({nameof(GenderId.Male)}|{nameof(GenderId.Female)}|{nameof(GenderId.Other)}|{nameof(GenderId.Unknown)})$", ErrorMessage = $"Please enter {nameof(GenderId.Male)} or {nameof(GenderId.Female)} or {nameof(GenderId.Other)} or {nameof(GenderId.Unknown)}.")]
        public string? Gender { get; set; }
        
        [Required]
        public DateTime? BirtDate { get; set; }

        [RegularExpression($"^({nameof(ActiveId.True)}|{nameof(ActiveId.False)})$", ErrorMessage = $"Please enter {nameof(ActiveId.True)} or {nameof(ActiveId.False)}.")]
        public bool? Active { get; set; }
    }
}
