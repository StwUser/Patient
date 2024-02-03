
using System.Reflection.Metadata;

namespace DataBasePatient.Data.Dtos
{
    public class NameDto
    {
        public Guid? Id { get; set; }
        public string? Use { get; set; }
        public string? Family {  get; set; }
        public List<string> Given { get; set; } = new List<string>();
    }
}
