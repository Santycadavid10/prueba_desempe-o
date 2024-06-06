using Teachers.Models;
using Academy.Data;

public class TeachersRepository : ITeachersRepository
{
    //coneccion ala data
    private readonly AcademyContext _context;
    public TeachersRepository(AcademyContext context)
    {
        _context = context;
    }

    //LISTAR TODOS LOS USUARIOS
    public IEnumerable<Teacher> GetAll()
    {
        return _context.Teachers.ToList();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7

    // LISTAR UN USUARIO POR ID
    public Teacher GetById(int id)
    {
        return _context.Teachers.Find(id);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

     // CREAR UN NUEVO AUTOR
    public Teacher Create(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return teacher;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



     // Actualizar un autor existente y devolver el autor actualizado
    public Teacher Update(Teacher updatedTeacher)
    {
        var existingTeacher = _context.Teachers.Find(updatedTeacher.Id);
        if (existingTeacher == null)
        {
            throw new ArgumentException("El autor no existe");
        }
        // Actualizar solo los campos que no son nulos en el objeto updatedAuthor
        if (updatedTeacher.Names != null)
        {
            existingTeacher.Names = updatedTeacher.Names;
        }

        if (updatedTeacher.Specialty != null)
        {
            existingTeacher.Specialty = updatedTeacher.Specialty;
        }

        if (updatedTeacher.Phone != null)
        {
            existingTeacher.Phone = updatedTeacher.Phone;
        }

        if (updatedTeacher.Email != null)
        {
            existingTeacher.Email = updatedTeacher.Email;
        }
        if (updatedTeacher.YearsExperience != null)
        {
            existingTeacher.YearsExperience = updatedTeacher.YearsExperience;
        }
        // Guardar los cambios en la base de datos
        _context.SaveChanges();
        return existingTeacher;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



}