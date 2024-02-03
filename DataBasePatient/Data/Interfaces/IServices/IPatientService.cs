using DataBasePatient.Data.Models;

namespace DataBasePatient.Data.Interfaces.IServices
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task<Guid> CreatePatientAsync(Patient patient);
        Task<bool> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientByIdAsync(Guid id);
    }
}
