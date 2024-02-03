using DatabaseCookingCoolR6.Data.Interfaces.IRepositories;
using DataBasePatient.Data;
using DataBasePatient.Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DataBasePatient.Repositories
{
    public class PatientRepository : IRepositoryCRUD<Patient>
    {
        public async Task<IEnumerable<Patient>> GetListAsync()
        {
            using var db = new AppDbContext();

            var result = await db.Patients
                .Include(p => p.Active)
                .Include(p => p.Gender)
                .ToListAsync();

            return result;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            using var db = new AppDbContext();
            var result = await db.Patients
                .Include(p => p.Active)
                .Include(p => p.Gender)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (result == null)
            {
                throw new ArgumentNullException();
            }

            return result;
        }

        public async Task<Guid> CreateAsync(Patient item)
        {
            using var db = new AppDbContext();
            await db.AddAsync(item);
            await db.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> UpdateAsync(Patient item)
        {
            using var db = new AppDbContext();
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var db = new AppDbContext();
            var item = await db.Patients.FirstOrDefaultAsync(u => u.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException();
            }

            db.Patients.Remove(item);
            await db.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
