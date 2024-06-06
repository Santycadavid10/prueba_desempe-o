using Teachers.Models;

  public interface ITeachersRepository
  {
    IEnumerable<Teacher> GetAll();//Listar todos los Profesor

    Teacher GetById(int id);//Listar un unico Profesor ID

    Teacher Create(Teacher teacher); // Crear un nuevo Profesor
    Teacher Update(Teacher updatedTeacher); // Actualizar un autor existente y devolver el autor actualizado

}