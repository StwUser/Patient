using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Models;
using DataBasePatient.Data;
using Microsoft.EntityFrameworkCore;

namespace DataBasePatient.Helpers
{
    public static class DataSeeder
    {
        public static void Seed()
        {
            using var db = new AppDbContext();

            if (!db.Gender.Any())
            {
                using var transaction = db.Database.BeginTransaction();
                
                var male = new Gender { Id = (int)GenderId.Male, GenderName = nameof(GenderId.Male) };
                var female = new Gender { Id = (int)GenderId.Female, GenderName = nameof(GenderId.Female) };
                var other = new Gender { Id = (int)GenderId.Other, GenderName = nameof(GenderId.Other) };
                var unknown = new Gender { Id = (int)GenderId.Unknown, GenderName = nameof(GenderId.Unknown) };

                db.Gender.AddRange(male, female, other, unknown);

                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Gender ON");
                db.SaveChanges();
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Gender OFF");

                transaction.Commit();
            }
            if (!db.Active.Any())
            {
                using var transaction = db.Database.BeginTransaction();

                var active = new Active { Id = (int)ActiveId.True, Value = true, ActiveName = nameof(ActiveId.True) };
                var notActive = new Active { Id = (int)ActiveId.False, Value = false, ActiveName = nameof(ActiveId.False) };
                db.Active.AddRange(active, notActive);

                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Active ON");
                db.SaveChanges();
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Active OFF");

                transaction.Commit();
            }
        }
    }
}
