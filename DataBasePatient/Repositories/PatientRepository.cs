﻿using DatabaseCookingCoolR6.Data.Interfaces.IRepositories;
using DataBasePatient.Data;
using DataBasePatient.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBasePatient.Repositories
{
    public class PatientRepository : IRepositoryCRUD<Patient, Given>
    {
        public async Task<IEnumerable<Patient>> GetListAsync()
        {
            using var db = new AppDbContext();

            var result = await db.Patients
                .Include(p => p.Active)
                .Include(p => p.Gender)
                .Include(p => p.Givens)
                .ToListAsync();

            return result;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
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

        public async Task<Guid> CreateAsync(Patient patient, IEnumerable<Given> givens)
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

        public async Task<bool> UpdateAsync(Patient patient, IEnumerable<Given> givens)
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
    }
}
