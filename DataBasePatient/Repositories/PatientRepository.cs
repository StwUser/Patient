using DatabaseCookingCoolR6.Data.Interfaces.IRepositories;
using DataBasePatient.Data;
using DataBasePatient.Data.Models;
using DataBasePatient.Helpers;
using Microsoft.EntityFrameworkCore;


namespace DataBasePatient.Repositories
{
    public class PatientRepository : IRepositoryCRUD<PatientDbo, Given>
    {
        public async Task<IEnumerable<PatientDbo>> GetListAsync()
        {
            using var db = new AppDbContext();

            var result = await db.Patients
                .Include(p => p.Active)
                .Include(p => p.Gender)
                .Include(p => p.Givens)
                .ToListAsync();

            return result;
        }

        public async Task<PatientDbo> GetByIdAsync(Guid id)
        {
            using var db = new AppDbContext();
            var result = await db.Patients
                .Include(p => p.Active)
                .Include(p => p.Gender)
                .Include(p => p.Givens)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (result == null)
            {
                throw new ArgumentNullException();
            }

            return result;
        }

        public async Task<Guid> CreateAsync(PatientDbo patient, IEnumerable<Given> givens)
        {
            using var db = new AppDbContext();
            await db.Patients.AddAsync(patient);
            await db.SaveChangesAsync();

            if (givens.Any())
            {
                foreach (var g in givens)
                {
                    patient.Givens.Add(new Given { PatientId = patient.Id, GivenName = g.GivenName });
                }
            }

            await db.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<bool> UpdateAsync(PatientDbo patient, IEnumerable<Given> givens)
        {
            using var db = new AppDbContext();
            db.Entry(patient).State = EntityState.Modified;
            await db.SaveChangesAsync();

            var newPatient = db.Patients.Include(p => p.Givens).FirstOrDefault(p => p.Id == patient.Id);

            if (givens.Any() && newPatient != null)
            {
                newPatient?.Givens.Clear();
                foreach (var g in givens)
                {
                    newPatient?.Givens.Add(new Given { PatientId = patient.Id, GivenName = g.GivenName });
                }
            }

            await db.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var db = new AppDbContext();
            var patient = await db.Patients.Include(p => p.Givens).FirstOrDefaultAsync(u => u.Id == id);

            if (patient == null)
            {
                throw new ArgumentNullException();
            }

            patient.Givens.Clear();
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<PatientDbo>> SearchPatientByDate(string date)
        {
            using var db = new AppDbContext();
            var patientQuery = db.Patients
                                    .Include(p => p.Active)
                                    .Include(p => p.Gender)
                                    .Include(p => p.Givens)
                                    .AsNoTracking()
                                    .AsQueryable();

            var result = PatientQueryFilter.SearchPatientByDate(patientQuery, date);

            if (result == null) 
            {
                throw new NotImplementedException();
            }

            return await result.ToArrayAsync();
        }
    }
}
