using DataBasePatient.Data.Dtos;
using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Interfaces.IServices;
using DataBasePatient.Data.Models;
using DataBasePatient.Repositories;

namespace DataBasePatient.Services
{
    public class PatientService : IPatientService
    {
        private readonly PatientRepository rp;

        public PatientService()
        {
            rp = new PatientRepository();
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
        {
            var patients = await rp.GetListAsync();

            var result = patients.Select(p => new PatientDto 
            { 
                Name = new NameDto 
                { 
                    Id = p.Id,
                    Family = p.Family,
                    Use = p.Use,
                    Given = p.Given.ToList()
                },
                Active = p.Active?.Value ?? false,
                BirtDate = p.BirthDate,
                Gender = p.Gender?.GenderName ?? nameof(GenderId.Unknown)
            });

            return result;
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await rp.GetByIdAsync(id);

            var result = new PatientDto
            {
                Name = new NameDto
                {
                    Id = patient.Id,
                    Family = patient.Family,
                    Given = patient.Given.ToList(),
                    Use = patient.Use
                },
                Active = patient.Active?.Value ?? false,
                BirtDate = patient.BirthDate,
                Gender = patient?.Gender?.GenderName ?? nameof(GenderId.Unknown)
            };

            return result;
        }

        public Task<Guid> CreatePatientAsync(Patient patient)
        {
            return rp.CreateAsync(patient);
        }

        public Task<bool> UpdatePatientAsync(Patient patient)
        {
            return rp.UpdateAsync(patient);
        }

        public Task<bool> DeletePatientByIdAsync(Guid id)
        {
            return rp.DeleteAsync(id);
        }
    }
}
