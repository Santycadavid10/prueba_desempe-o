using Enrollments.Models;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ViewsEnrollmentsController : ControllerBase
{
    private readonly IEnrollmentsRepository _enrollmentsRepository;

    public ViewsEnrollmentsController(IEnrollmentsRepository enrollmentsRepository)
    {
        _enrollmentsRepository = enrollmentsRepository;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Listar todos los autores
     [HttpGet]
    public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
    {
    var coursesWithTeacher = await _enrollmentsRepository.GetAllEnrollmentsWithdateAsync();

    return Ok(coursesWithTeacher);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Listar autor por ID
  [HttpGet("ListarCursoPorId/{id}")]
  public  async Task<ActionResult<IEnumerable<Enrollment>>> GetById(int id)
  {
    var Cours = _enrollmentsRepository.GetById(id);
    if (Cours == null)
    {
      return NotFound();
    }

    
    return Ok(Cours);
  }



}