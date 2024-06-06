using Students.Models;

  public interface IStudentsRepository
  {
    IEnumerable<Student> GetAll();//Listar todos los estudiantes

    Student GetById(int id);//Listar un unico estudienta ID


     Student Create(Student student); // Crear un nuevo estudiante

     Student Update(Student updatedStudent); // Actualizar un autor existente y devolver el autor actualizado
  }