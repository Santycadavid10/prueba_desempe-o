using Teachers.Models;
using Microsoft.AspNetCore.Mvc;
public class UpdateTeachersController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly ITeachersRepository _teachersRepository;

    public UpdateTeachersController(ITeachersRepository teachersRepository)
    {
        _teachersRepository = teachersRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////7
    //Método para Actualizar autor 
    [HttpPut("ActualizarProfe/{Id}")]
    public IActionResult Update(Teacher updatedTeacher)
    {
        if (updatedTeacher == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedEntity = _teachersRepository.Update(updatedTeacher);
            return Ok(updatedEntity);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}