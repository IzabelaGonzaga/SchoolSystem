using Application.DTO;
using Data.Repositories;
using Domain.Model;

namespace Application.UseCases

{
    public static class ClassUseCase
    {
        public static Class GetClassById(IClassRepository repository, int id)
        {
            return repository.GetById(id);
        }

        public static List<Class> GetClasses(IClassRepository repository)
        {
            return repository.GetAll();
        }

        public static void AddClass(IClassRepository repository, ClassDto classDto)
        {
            var classEntity = new Class()
            {
                Title = classDto.Title,
                Description = classDto.Description,
                StartDate = classDto.StartDate,
                Status = EStatus.Active,
                Registers = []
            };

            repository.Add(classEntity);
        }

        public static void UpdateClass(IClassRepository repository, ClassDto classDto, int id)
        {
            var classEntity = repository.GetById(id) ?? throw new Exception("Class not found.");

            classEntity.Title = classDto.Title;
            classEntity.Description = classDto.Description;
            classEntity.StartDate = classDto.StartDate;
            classEntity.Status = EStatus.Active;

            repository.Update(classEntity);
        }

        public static void RemoveClass(IClassRepository repository, int id)
        {
            repository.Delete(id);
        }

        public static void UpdateClassStatus(IClassRepository repository, int id, UpdateStatusRequest request)
        {
            var classEntity = repository.GetById(id) ?? throw new Exception("Class not found."); ;
            classEntity.Status = (EStatus)request.Status;

            repository.Update(classEntity);
        }
    }
}