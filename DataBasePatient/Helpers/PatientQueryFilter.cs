using DataBasePatient.Data.Models;
using System.Globalization;
using System.Linq;

namespace DataBasePatient.Helpers
{
    public static class PatientQueryFilter
    {
        public static IQueryable<PatientDbo> SearchPatientByDate(IQueryable<PatientDbo> query, string date)
        {
            var key = date[..2];
            var parsedDate = DateTime.Parse(date.Substring(2), CultureInfo.InvariantCulture);
            switch (key)
            {
                case "eq": return query.Where(q => q.BirthDate >= new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day) && q.BirthDate < new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day).AddDays(1));
                case "ne": return query.Where(q => q.BirthDate < parsedDate || q.BirthDate > parsedDate.AddDays(1));
                case "lt": return query.Where(q => q.BirthDate < parsedDate);
                case "gt": return query.Where(q => q.BirthDate > parsedDate);
                case "ge": return query.Where(q => q.BirthDate >= new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day));
                case "le": return query.Where(q => q.BirthDate >= new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day));
                case "sa": return query.Where(q => q.BirthDate > new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day));
                case "eb": return query.Where(q => q.BirthDate < new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day));
                case "ap": return query.Where(q => q.BirthDate == parsedDate);
                default: return null;
            }
        }
    }
}
