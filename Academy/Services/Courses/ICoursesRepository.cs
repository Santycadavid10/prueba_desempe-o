using Courses.Models;
using Academy.Data;

  public interface ICoursesRepository
  {
    Task<List<Cours>> GetAllCourses();
    Task<List<Cours>> GetAllCoursesWithTeacherAsync();


    Cours GetById(int id);//Listar un unico autor ID
    Task<List<Cours>> GetByIdWithTeacherAsync();

     Cours Create(Cours cours); // Crear un nuevo curso

     Cours Update(Cours updatedCours); // Actualizar un autor existente y devolver el autor actualizado

    
  }