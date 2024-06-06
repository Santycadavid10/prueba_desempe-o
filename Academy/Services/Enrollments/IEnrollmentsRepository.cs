using Enrollments.Models;



  public interface IEnrollmentsRepository
  {
    Task<List<Enrollment>> GetAllEnrollments();
    Task<List<Enrollment>> GetAllEnrollmentsWithdateAsync();


    Enrollment GetById(int id);//Listar un unico autor ID
    Task<List<Enrollment>> GetByIdWithTeacherAsync();

     Enrollment Create(Enrollment enrollment); // Crear un nuevo curso

     Enrollment Update(Enrollment updatedEnrollment); // Actualizar un autor existente y devolver el autor actualizado

    
  }