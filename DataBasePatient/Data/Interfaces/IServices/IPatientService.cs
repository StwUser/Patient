using DataBasePatient.Data.Dtos;
using DataBasePatient.Data.Models;

namespace DataBasePatient.Data.Interfaces.IServices
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetPatientsAsync();
        Task<IEnumerable<PatientDto>> SearchPatientsByDateAsync(string date);
        Task<PatientDto> GetPatientByIdAsync(Guid id);
        Task<Guid> CreatePatientAsync(PatientDto patient);
        Task<bool> UpdatePatientAsync(PatientDto patient);
        Task<bool> DeletePatientByIdAsync(Guid id);
    }
}
