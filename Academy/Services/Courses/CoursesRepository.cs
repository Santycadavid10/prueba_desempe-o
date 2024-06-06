using System.Collections.Generic;
using System.Threading.Tasks;
using Courses.Models;
using Academy.Data;
using Microsoft.EntityFrameworkCore;

public class CoursesRepository : ICoursesRepository
{
    private readonly AcademyContext _context;

    public CoursesRepository(AcademyContext context)
    {
        _context = context;
    }

    public async Task<List<Cours>> GetAllCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<List<Cours>> GetAllCoursesWithTeacherAsync()
    {
        return await _context.Courses
            .Include(Cours => Cours.Teacher)
            .ToListAsync();
    }




     // LISTAR UN USUARIO POR ID
    public Cours GetById(int id)
    {
        return _context.Courses.Find(id);
    }
    public async Task<List<Cours>> GetByIdWithTeacherAsync()
    {
        return await _context.Courses
            .Include(static Cours => Cours.Teacher)
            .ToListAsync();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // CREAR UN NUEVO AUTOR
    public Cours Create(Cours cours)
    {
        _context.Courses.Add(cours);
        _context.SaveChanges();
        return cours;
    }



     // Actualizar un autor existente y devolver el autor actualizado
    public Cours Update(Cours updatedCours)
    {
        var existingCours = _context.Courses.Find(updatedCours.Id);
        if (existingCours == null)
        {
            throw new ArgumentException("El autor no existe");
        }
        // Actualizar solo los campos que no son nulos en el objeto updatedAuthor
        if (updatedCours.Name != null)
        {
            existingCours.Name = updatedCours.Name;
        }

        if (updatedCours.Description != null)
        {
            existingCours.Description = updatedCours.Description;
        }

        if (updatedCours.TeacherId != null)
        {
            existingCours.TeacherId = updatedCours.TeacherId;
        }

        if (updatedCours.Schedulecours != null)
        {
            existingCours.Schedulecours = updatedCours.Schedulecours;
        }
        if (updatedCours.Duration != null)
        {
            existingCours.Duration = updatedCours.Duration;
        }
        if (updatedCours.Capacity != null)
        {
            existingCours.Capacity = updatedCours.Capacity;
        }
        // Guardar los cambios en la base de datos
        _context.SaveChanges();
        return existingCours;
    }
}