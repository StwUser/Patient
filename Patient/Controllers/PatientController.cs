using DataBasePatient.Data.Interfaces.IServices;
using DataBasePatient.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await patientService.GetPatientsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Patient> GetUsersByIdAsync(Guid id)
        {
            return await patientService.GetPatientByIdAsync(id);
        }

        [HttpPost]
        public async Task<Guid> CreatePatientAsync(Patient patient)
        {
            return await patientService.CreatePatientAsync(patient);
        }

        [HttpPut]
        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            return await patientService.UpdatePatientAsync(patient);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeletePatientByIdAsync(Guid id)
        {
            return await patientService.DeletePatientByIdAsync(id);
        }
    }
}
