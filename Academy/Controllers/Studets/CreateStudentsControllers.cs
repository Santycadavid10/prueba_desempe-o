
using Microsoft.AspNetCore.Mvc;
using Students.Models;
public class CreateStudentsController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly IStudentsRepository _studentsRepository;
    public CreateStudentsController(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Crear un nuevo autor
    [HttpPost("CrearEstudiante")]
    public ActionResult<Student> Create(Student student)
    {
        _studentsRepository.Create(student);
        return CreatedAtAction("GetById", "ViewsStudents", new { id = student.Id }, student);//RETORNO EL AUTOR CREADO Y LLAMO AL METODO GetById
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7
}