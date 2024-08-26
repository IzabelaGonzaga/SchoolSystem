using Data.Repositories;
using Domain.Model;

namespace Application.UseCases
{
    public class StudentUseCase
    {
        private IStudentRepository _repository;

        public void AddStudent(Student student)
        {
            var _student = new Student()
            {
                Name = student.Name,
                Email = student.Email,
                Address = student.Address,
                Status = EStatus.Active,
                Registers = new List<Register>()
            };

            _repository.Add(_student);
        }

    }
}
