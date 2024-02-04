
using DataBasePatient.Data.Dtos;
using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Models;

namespace DataBasePatient.Helpers
{
    public static class PatientConverter
    {
        public static IEnumerable<PatientDto> PatientsToPatienDtos(IEnumerable<Patient> patients)
        {
            return patients.Select(p => new PatientDto
            {
                Name = new NameDto
                {
                    Id = p.Id,
                    Family = p.Family,
                    Use = p.Use,
                    Given = p.Givens.Select(g => g.GivenName ?? string.Empty).ToList(),
                },
                Active = p.Active?.Value ?? false,
                BirtDate = p.BirthDate,
                Gender = p.Gender?.GenderName ?? nameof(GenderId.Unknown)
            });
        }

        public static PatientDto PatientToPatientDto(Patient patient)
        {
            return new PatientDto
            {
                Name = new NameDto
                {
                    Id = patient.Id,
                    Family = patient.Family,
                    Given = patient.Givens.Select(g => g.GivenName ?? string.Empty).ToList(),
                    Use = patient.Use
                },
                Active = patient.Active?.Value ?? false,
                BirtDate = patient.BirthDate,
                Gender = patient?.Gender?.GenderName ?? nameof(GenderId.Unknown)
            };
        }

        public static (Patient, List<Given>) PatientDtoToPatient(PatientDto patientDto)
        {
            var result = new Patient
            {
                Use = patientDto?.Name?.Use,
                Family = patientDto?.Name?.Family,
                BirthDate = patientDto?.BirtDate ?? throw new ArgumentNullException(nameof(patientDto)),
            };

            var givens = new List<Given>();

            if (patientDto?.Name?.Id.HasValue ?? false) 
            {
                result.Id = (Guid)patientDto.Name.Id;
            }

            if (!string.IsNullOrEmpty(patientDto?.Gender))
            {
                Enum.TryParse(patientDto.Gender, out GenderId gender);
                result.GenderId = (int)gender;
            }

            if (patientDto?.Active.HasValue ?? false)
            {
                result.ActiveId = patientDto.Active.Value ? (int)ActiveId.True : (int)ActiveId.False;
            }

            if (patientDto?.Name != null && patientDto.Name.Given.Count > 0)
            {
                
                foreach(var prop in patientDto.Name.Given) 
                { 
                    givens.Add(new Given { GivenName = prop });
                }
            }

            return (result, givens);
        }
    }
}
