using DataBasePatient.Data.Dtos;
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
        public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
        {
            return await patientService.GetPatientsAsync();
        }

        [HttpGet("{id}")]
        public async Task<PatientDto> GetUsersByIdAsync(Guid id)
        {
            return await patientService.GetPatientByIdAsync(id);
        }

        [HttpPost]
        public async Task<Guid> CreatePatientAsync(PatientDto patient)
        {
            return await patientService.CreatePatientAsync(patient);
        }

        [HttpPut]
        public async Task<bool> UpdatePatientAsync(PatientDto patient)
        {
            return await patientService.UpdatePatientAsync(patient);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeletePatientByIdAsync(Guid id)
        {
            return await patientService.DeletePatientByIdAsync(id);
        }

        [HttpGet("SearchByDate/{date}")]
        public async Task<IEnumerable<PatientDto>> SearchByDate(string date)
        {
            return await patientService.SearchPatientsByDateAsync(date);
        }
    }
}
