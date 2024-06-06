using Courses.Models;
using Microsoft.AspNetCore.Mvc;
public class UpdateCoursesController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly ICoursesRepository _coursesRepository;

    public UpdateCoursesController(ICoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////7
    //Método para Actualizar autor 
    [HttpPut("ActualizarCurso/{Id}")]
    public IActionResult Update(Cours updatedCours)
    {
        if (updatedCours == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedEntity = _coursesRepository.Update(updatedCours);
            return Ok(updatedEntity);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}