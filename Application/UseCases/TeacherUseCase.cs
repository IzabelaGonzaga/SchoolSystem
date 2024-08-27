using Application.DTO;
using Data.Repositories;
using Domain.Model;
using Microsoft.IdentityModel.Tokens;

namespace Application.UseCases
{
    public class TeacherUseCase
    {
        public static Teacher GetTeacherById(ITeacherRepository repository, int id)
        {
            return repository.GetById(id);
        }

        public static List<Teacher> GetTeachers(ITeacherRepository repository)
        {
            return repository.GetAll();
        }

        public static void AddTeacher(ITeacherRepository repository, TeacherDto teacherDto)
        {
            if (teacherDto.Name.IsNullOrEmpty() || teacherDto.Email.IsNullOrEmpty())
            {
                throw new Exception("The following user informations are mandatory: name, email.");
            }

            var student = new Teacher(teacherDto.Name, teacherDto.Email);
            repository.Add(student);
        }

        public static void UpdateTeacher(ITeacherRepository repository, TeacherDto teacherDto, int id)
        {
            try
            {
                var teacherEntity = repository.GetById(id);
                teacherEntity.Name = teacherDto.Name ?? teacherEntity.Name;
                teacherEntity.Email = teacherDto.Email ?? teacherEntity.Email;

                repository.Update(teacherEntity);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void RemoveTeacher(ITeacherRepository repository, int id)
        {
            repository.Delete(id);
        }
    }
}
