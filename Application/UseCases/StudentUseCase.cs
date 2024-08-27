using Application.DTO;
using Data.Repositories;
using Domain.Model;

//TODO: deveria ter um uso de caso só para desativar o aluno, sem precisar colocar todos os dados
namespace Application.UseCases
{
    public static class StudentUseCase
    {
        public static Student GetStudentById(IStudentRepository repository, int id)
        {
            return repository.GetById(id);
        }

        public static List<Student> GetStudents(IStudentRepository repository)
        {
            return repository.GetAll();
        }

        //TODO:O status aparece no request body não fica como opcional
        public static void AddStudent(IStudentRepository repository, StudentDto studentDto)
        {
            var student = new Student()
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Address = studentDto.Address,
                Status = EStatus.Active,
                Registers = []
            };

            repository.Add(student);
        }

        public static void UpdateStudent(IStudentRepository repository, StudentDto studentDto, int id)
        {
            var studentEntity = repository.GetById(id) ?? throw new Exception("Class not found.");
            studentEntity = new Student()
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Address = studentDto.Address,
                Status = EStatus.Active,
                Registers = studentEntity.Registers,
            };

            repository.Update(studentEntity);
        }

        public static void RemoveStudent(IStudentRepository repository, int id)
        {
            repository.Delete(id);
        }
    }
}