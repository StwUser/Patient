using DataBasePatient.Data.Dtos;
using DataBasePatient.Data.Interfaces.IServices;
using DataBasePatient.Helpers;
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
            return PatientConverter.PatientsToPatienDtos(patients);
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await rp.GetByIdAsync(id);
            return PatientConverter.PatientToPatientDto(patient);
        }

        public Task<Guid> CreatePatientAsync(PatientDto patientDto)
        {
            var (patient, givens) = PatientConverter.PatientDtoToPatient(patientDto);
            return rp.CreateAsync(patient, givens);
        }

        public Task<bool> UpdatePatientAsync(PatientDto patientDto)
        {
            var (patient, givens) = PatientConverter.PatientDtoToPatient(patientDto);
            return rp.UpdateAsync(patient, givens);
        }

        public Task<bool> DeletePatientByIdAsync(Guid id)
        {
            return rp.DeleteAsync(id);
        }
    }
}
