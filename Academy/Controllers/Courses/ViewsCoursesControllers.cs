using Courses.Models;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ViewsCoursesController : ControllerBase
{
    private readonly ICoursesRepository _coursesRepository;

    public ViewsCoursesController(ICoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Listar todos los autores
     [HttpGet]
    public async Task<ActionResult<IEnumerable<Cours>>> GetCourses()
    {
    var coursesWithTeacher = await _coursesRepository.GetAllCoursesWithTeacherAsync();

    return Ok(coursesWithTeacher);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Listar autor por ID
  [HttpGet("ListarCursoPorId/{id}")]
  public  async Task<ActionResult<IEnumerable<Cours>>> GetById(int id)
  {
    var Cours = _coursesRepository.GetById(id);
    if (Cours == null)
    {
      return NotFound();
    }

    
    return Ok(Cours);
  }



}