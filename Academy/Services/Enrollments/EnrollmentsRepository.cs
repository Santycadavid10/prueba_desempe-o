using System.Collections.Generic;
using System.Threading.Tasks;
using Enrollments.Models;
using Academy.Data;
using Microsoft.EntityFrameworkCore;

public class EnrollmentsRepository : IEnrollmentsRepository
{
    private readonly AcademyContext _context;

    public EnrollmentsRepository(AcademyContext context)
    {
        _context = context;
    }

    public async Task<List<Enrollment>> GetAllEnrollments()
    {
        return await _context.Enrollments.ToListAsync();
    }

    public async Task<List<Enrollment>> GetAllEnrollmentsWithdateAsync()
    {
        return await _context.Enrollments
            .Include(Enrollment => Enrollment.Student)
            .Include(Enrollment => Enrollment.Cours)
            .ToListAsync();
    }




     // LISTAR UN USUARIO POR ID
    public Enrollment GetById(int id)
    {
        return _context.Enrollments.Find(id);
    }
    public async Task<List<Enrollment>> GetByIdWithTeacherAsync()
    {
        return await _context.Enrollments
            .Include(static Enrollment => Enrollment.Student)
            .Include(static Enrollment => Enrollment.Cours)
            .ToListAsync();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // CREAR UN NUEVO AUTOR
    public Enrollment Create(Enrollment enrollment)
    {
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();
        return enrollment;
    }



     // Actualizar un autor existente y devolver el autor actualizado
    public Enrollment Update(Enrollment updatedEnrollment)
    {
        var existingEnrollment = _context.Enrollments.Find(updatedEnrollment.Id);
        if (existingEnrollment == null)
        {
            throw new ArgumentException("El autor no existe");
        }
        // Actualizar solo los campos que no son nulos en el objeto updatedAuthor
        if (updatedEnrollment.DateEnrollments != null)
        {
            existingEnrollment.DateEnrollments = updatedEnrollment.DateEnrollments;
        }

        if (updatedEnrollment.StudentId != null)
        {
            existingEnrollment.StudentId = updatedEnrollment.StudentId;
        }

        if (updatedEnrollment.CoursId != null)
        {
            existingEnrollment.CoursId = updatedEnrollment.CoursId;
        }

        if (updatedEnrollment.Status != null)
        {
            existingEnrollment.Status = updatedEnrollment.Status;
        }
        
        // Guardar los cambios en la base de datos
        _context.SaveChanges();
        return existingEnrollment;
    }
}