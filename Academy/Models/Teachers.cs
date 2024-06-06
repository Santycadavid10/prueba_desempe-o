using   Courses.Models;
using System.Text.Json.Serialization;

namespace Teachers.Models;
public class Teacher
{
    public int Id { get; set; }
    public string? Names { get; set; }
    public string?	Specialty{ get; set; }
    public string? Phone { get; set; }
    public string? 	Email { get; set; }
    public int? YearsExperience { get; set; }
    [JsonIgnore]
    public ICollection<Cours> Courses { get; set; } = new List<Cours>();
}