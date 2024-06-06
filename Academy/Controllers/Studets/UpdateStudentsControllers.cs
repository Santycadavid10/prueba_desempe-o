using Students.Models;
using Microsoft.AspNetCore.Mvc;
public class UpdateStudentsController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly IStudentsRepository _studentsRepository;

    public UpdateStudentsController(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////7
    //Método para Actualizar autor 
    [HttpPut("Actualizarestudiante/{Id}")]
    public IActionResult Update(Student updatedStudent)
    {
        if (updatedStudent == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedEntity = _studentsRepository.Update(updatedStudent);
            return Ok(updatedEntity);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}