using System.Text.Json.Serialization;
using Enrollments.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models;
public class Student
{
    public int Id { get; set; }
    public string? Names { get; set; }
    public DateTime?	BirthDate{ get; set; }
    public string? Address { get; set; }
    public string? 	Email { get; set; }

    [JsonIgnore]
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}