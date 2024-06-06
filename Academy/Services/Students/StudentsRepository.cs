using Students.Models;
using Academy.Data;

public class StudentsRepository : IStudentsRepository
{
    //coneccion ala data
    private readonly AcademyContext _context;
    public StudentsRepository(AcademyContext context)
    {
        _context = context;
    }

    //LISTAR TODOS LOS USUARIOS
    public IEnumerable<Student> GetAll()
    {
        return _context.Students.ToList();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7

    // LISTAR UN USUARIO POR ID
    public Student GetById(int id)
    {
        return _context.Students.Find(id);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // CREAR UN NUEVO AUTOR
    public Student Create(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return student;
    }


     // Actualizar un autor existente y devolver el autor actualizado
    public Student Update(Student updatedStudent)
    {
        var existingStudent = _context.Students.Find(updatedStudent.Id);
        if (existingStudent == null)
        {
            throw new ArgumentException("El autor no existe");
        }
        // Actualizar solo los campos que no son nulos en el objeto updatedAuthor
        if (updatedStudent.Names != null)
        {
            existingStudent.Names = updatedStudent.Names;
        }

        if (updatedStudent.BirthDate != null)
        {
            existingStudent.BirthDate = updatedStudent.BirthDate;
        }

        if (updatedStudent.Address != null)
        {
            existingStudent.Address = updatedStudent.Address;
        }

        if (updatedStudent.Email != null)
        {
            existingStudent.Email = updatedStudent.Email;
        }
        // Guardar los cambios en la base de datos
        _context.SaveChanges();
        return existingStudent;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


}