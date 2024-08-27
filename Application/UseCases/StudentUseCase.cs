using Application.DTO;
using Data.Repositories;
using Domain.Model;
using Microsoft.IdentityModel.Tokens;

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

        public static void AddStudent(IStudentRepository repository, StudentDto studentDto)
        {
            if(studentDto.Name.IsNullOrEmpty() || studentDto.Email.IsNullOrEmpty() || studentDto.Address.IsNullOrEmpty())
            {
                throw new Exception("The following user informations are mandatory: name, email and address.");
            }

            var student = new Student(studentDto.Name, studentDto.Email, studentDto.Address);
            repository.Add(student);
        }

        public static void UpdateStudent(IStudentRepository repository, StudentDto studentDto, int id)
        {
            try
            {
                var studentEntity = repository.GetById(id);
                studentEntity.Name = studentDto.Name ?? studentEntity.Name;
                studentEntity.Email = studentDto.Email ?? studentEntity.Email;
                studentEntity.Address = studentDto.Address ?? studentEntity.Address;

                repository.Update(studentEntity);

            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DisableStudent(IStudentRepository repository, int id)
        {
            try
            {
                var studentEntity = repository.GetById(id);
                studentEntity.Status = EUserStatus.Inactive;

                repository.Update(studentEntity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void RemoveStudent(IStudentRepository repository, int id)
        {
            repository.Delete(id);
        }
    }
}