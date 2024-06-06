using Students.Models;
using Courses.Models;
using System.Text.Json.Serialization;


namespace Enrollments.Models;

public enum EnrollmentStatus
{
    Inactive = 0,
    Active = 1
}
public class Enrollment
{

    public int Id { get; set; }
    public DateTime? DateEnrollments	 { get; set; }
    // Claves foráneas
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int CoursId { get; set; }
    public Cours? Cours { get; set; }
    public EnrollmentStatus? Status { get; set; }
    

}