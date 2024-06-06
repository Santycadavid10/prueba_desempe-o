using Courses.Models;
using Microsoft.AspNetCore.Mvc;
public class CreateCoursesController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly ICoursesRepository _coursesRepository;
    public CreateCoursesController(ICoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Crear un nuevo autor
    [HttpPost("CrearCurso")]
    public ActionResult<Cours> Create(Cours cours)
    {
        _coursesRepository.Create(cours);
        return CreatedAtAction("GetById", "ViewsCourses", new { id = cours.Id }, cours);//RETORNO EL AUTOR CREADO Y LLAMO AL METODO GetById
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7
}