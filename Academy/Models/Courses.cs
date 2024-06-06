using Teachers.Models;
using Enrollments.Models;
using System.Text.Json.Serialization;

namespace Courses.Models;
public class Cours
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? TeacherId  { get; set; }
    public Teacher? Teacher { get; set; }
    public string? Schedulecours { get; set; }
    public string? 	Duration { get; set; }
    public int Capacity { get; set; }
    [JsonIgnore]
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}


