using Enrollments.Models;
using Microsoft.AspNetCore.Mvc;
public class CreateEnrollmentsController : ControllerBase
{
    //coneccion a AuthorRepository
    private readonly IEnrollmentsRepository _enrollmentsRepository;
    public CreateEnrollmentsController(IEnrollmentsRepository enrollmentsRepository)
    {
        _enrollmentsRepository = enrollmentsRepository;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Crear un nuevo autor
    [HttpPost("Crearmatricula")]
    public ActionResult<Enrollment> Create(Enrollment Enrollment)
    {
        _enrollmentsRepository.Create(Enrollment);
        return CreatedAtAction("GetById", "ViewsEnrollment", new { id = Enrollment.Id }, Enrollment);//RETORNO EL AUTOR CREADO Y LLAMO AL METODO GetById
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7
}