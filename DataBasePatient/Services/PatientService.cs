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

        public Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return rp.GetListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            var result = await rp.GetByIdAsync(id);
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
