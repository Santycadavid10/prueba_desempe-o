using Microsoft.EntityFrameworkCore;
using Students.Models;
using Teachers.Models;
using Courses.Models;
using Enrollments.Models;

namespace Academy.Data;
public class AcademyContext : DbContext
{
    public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
    {
    }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Teacher> Teachers{ get; set; }

    public DbSet<Cours> Courses { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }



      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cours>()
            .HasOne(b => b.Teacher)
            .WithMany(a => a.Courses)
            .HasForeignKey(b => b.TeacherId);


        modelBuilder.Entity<Enrollment>()
            .HasOne(b => b.Student)
            .WithMany(a => a.Enrollments)
            .HasForeignKey(b => b.StudentId);


        modelBuilder.Entity<Enrollment>()
            .HasOne(b => b.Cours)
            .WithMany(a => a.Enrollments)
            .HasForeignKey(b => b.CoursId);
    }
    
}






