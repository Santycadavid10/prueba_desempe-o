using Teachers.Models;
using Microsoft.AspNetCore.Mvc;
public class CreateTeachersController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly ITeachersRepository _teachersRepository;
    public CreateTeachersController(ITeachersRepository teachersRepository)
    {
        _teachersRepository = teachersRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Crear un nuevo autor
    [HttpPost("CrearAutor")]
    public ActionResult<Teacher> Create(Teacher teacher)
    {
        _teachersRepository.Create(teacher);
        return CreatedAtAction("GetById", "ViewsTeachers", new { id = teacher.Id }, teacher);//RETORNO EL AUTOR CREADO Y LLAMO AL METODO GetById
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7
}