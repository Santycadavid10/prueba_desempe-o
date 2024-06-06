using Teachers.Models;
using Microsoft.AspNetCore.Mvc;

public class ViewsTeachersController : ControllerBase
{
  //coneccion a AuthorRepository
  private readonly ITeachersRepository _teachersRepository;
  public ViewsTeachersController(ITeachersRepository teachersRepository)
  {
    _teachersRepository = teachersRepository;
  }
  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Listar todos los autores
  [HttpGet("ListarTodosLosProfes")]
  public IEnumerable<Teacher> GetAll()

  {
    return  _teachersRepository.GetAll();
  }
  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Listar autor por ID
  [HttpGet("ListarProfesPorId/{id}")]
  public ActionResult<Teacher> GetById(int id)
  {
    var Teacher = _teachersRepository.GetById(id);
    if (Teacher == null)
    {
      return NotFound();
    }
    return Ok(Teacher);
  }

}