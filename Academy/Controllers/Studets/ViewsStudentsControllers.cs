using Students.Models;
using Microsoft.AspNetCore.Mvc;

public class ViewsStudentsController : ControllerBase
{
  //coneccion a AuthorRepository
  private readonly IStudentsRepository _studentsRepository;
  public ViewsStudentsController(IStudentsRepository studentsRepository)
  {
    _studentsRepository = studentsRepository;
  }
  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Listar todos los autores
  [HttpGet("ListarTodosLosestudientes")]
  public IEnumerable<Student> GetAll()

  {
    return  _studentsRepository.GetAll();
  }
  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // Listar autor por ID
  [HttpGet("ListarAutorPorId/{id}")]
  public ActionResult<Student> GetById(int id)
  {
    var Student = _studentsRepository.GetById(id);
    if (Student == null)
    {
      return NotFound();
    }
    return Ok(Student);
  }

}